using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Business.Service;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;

namespace Vogue2_IMS.Business
{
    public class RoleBusiness : BusinessBase<RoleBusiness>
    {
        public event EventHandler<CusEventArgs> OnRoleColumnsUpdated;

        public void AddRole(RoleInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspAddRole";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "AddRole.uspAddRole", true);
        }


        public IList<RoleInfo> GetRoles()
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetRoles";

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetRoles.uspGetRoles", true);

            return DoFunctionWithLog<List<RoleInfo>>(() =>
            {
                return ConvertToList<RoleInfo>(result);

            }, null, "GetRoles.ConvertToList", true);
        }

        public void UpdateRole(RoleInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdateRole";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdateRole.uspUpdateRole", true);
        }


        public void UpdateRoleColumns(int roleId, List<TableColumnInfo> columns)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdateRoleColumns";

                functionParms.Pams = new Dictionary<string, object>();
                functionParms.Pams.Add("@RoleColumnRoleId", roleId);

                string columnIds = string.Empty;
                columns.ForEach(column => columnIds += column.Id + ",");
                functionParms.Pams.Add("@RoleColumnColumnIds", columnIds.TrimEnd(','));

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdateRoleColumns.uspUpdateRoleColumns", true);

            if (!result.Faild && OnRoleColumnsUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnRoleColumnsUpdated, "UpdateRoleColumns", true);
            }
        }

        public List<RoleColumnsInfo> GetRoleColumns()
        {
            List<RoleColumnsInfo> roleColumns = new List<RoleColumnsInfo>();

            var listRole = SharedVariables.Instance.RoleInfos;
            var listColumn = SharedVariables.Instance.TableColumnInfos;

            foreach (var role in listRole)
            {
                if (role.Id != SharedVariables.AdminRoleId && string.IsNullOrEmpty(role.RoleColumnIds))
                {
                    roleColumns.Add(new RoleColumnsInfo()
                    {
                        Role = role,
                        TableColumn = null
                    });
                    continue;
                }

                foreach (var column in listColumn)
                {
                    if (role.Id == SharedVariables.AdminRoleId)//超级管理员
                    {
                        roleColumns.Add(new RoleColumnsInfo()
                        {
                            Role = role,
                            TableColumn = column
                        });
                        continue;
                    }

                    int[] roleColumnIds = role.RoleColumnIds.Split(',')
                             .Select(id => { return Convert.ToInt32(id); })
                             .ToArray();

                    if (roleColumnIds.Contains(column.Id))
                    {
                        roleColumns.Add(new RoleColumnsInfo()
                        {
                            Role = role,
                            TableColumn = column
                        });
                    }
                }
            }

            return roleColumns;
        }


        public List<TableColumnInfo> GetRoleColumns(int roleId, bool enabled)
        {
            var listColumn = SharedVariables.Instance.TableColumnInfos.ToList();
            if (roleId == SharedVariables.AdminRoleId)// 管理员，所有列权限
            {
                return enabled ? listColumn : null;
            }
            var role = SharedVariables.Instance.RoleInfos.FirstOrDefault(e => e.Id == roleId);
            if (string.IsNullOrEmpty(role.RoleColumnIds))
            {
                return enabled ? null : listColumn;
            }
            var columns = listColumn.Where(column =>
            {
                int[] columnIds = role.RoleColumnIds.Split(',')
                    .Select(id => { return Convert.ToInt32(id); })
                    .ToArray();

                return enabled ? columnIds.Contains(column.Id) : !columnIds.Contains(column.Id);
            }).ToList();

            return columns;
        }
    }
}
