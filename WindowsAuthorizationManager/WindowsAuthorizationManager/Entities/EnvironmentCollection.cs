using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace WindowsAuthorizationManager.Entities
{
    [Serializable]
    [XmlRoot("EnvironmentCollection")]
    public class EnvironmentCollection : IEnumerable<EnvironmentEntity>, IList<EnvironmentEntity>, ICollection<EnvironmentEntity>
    {
        public EnvironmentCollection()
            : this(null)
        { }

        public EnvironmentCollection(IEnumerable<EnvironmentEntity> environmentEntities)
        {
            this.items = new List<EnvironmentEntity>();
            if (environmentEntities != null)
            {
                this.items.AddRange(environmentEntities);
            }
        }

        private List<EnvironmentEntity> items;
        private EnvironmentEntity[] environmentEntity;
        [XmlElement("Environment")]
        public EnvironmentEntity[] ReportItems
        {
            get
            {
                return items.ToArray();
            }
            set
            {
                items.Clear();
                if (value == null) return;
                items.AddRange(value);
            }
        }

        public IEnumerator<EnvironmentEntity> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public int IndexOf(EnvironmentEntity item)
        {
            return this.items.IndexOf(item);
        }

        public void Insert(int index, EnvironmentEntity item)
        {
            this.items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.items.RemoveAt(index);
        }

        public EnvironmentEntity this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                this.items[index] = value;
            }
        }

        public void Add(EnvironmentEntity item)
        {
            this.items.Add(item);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(EnvironmentEntity item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(EnvironmentEntity[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(EnvironmentEntity item)
        {
            return this.items.Remove(item);
        }
    }
}
