using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime;

namespace Vogue2_IMS.Common
{
    public class ListExtend<T> : List<T>
    {
        public event CollectionChangeEventHandler CollectionChanged;

        public new void Add(T item)
        {
            base.Add(item);

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
            }
        }

        public new void Remove(T item)
        {
            base.Add(item);

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
            }
        }

        public new T this[int index]
        {
            get { return base[index]; }
            set
            {
                base[index] = value;

                if (CollectionChanged != null)
                {
                    CollectionChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
                }
            }
        }

        //
        // 摘要:
        //     从 System.Collections.Generic.List<T> 中移除所有元素。
        public new void Clear()
        {
            base.Clear();

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
            }
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
            }
        }
    }
}
