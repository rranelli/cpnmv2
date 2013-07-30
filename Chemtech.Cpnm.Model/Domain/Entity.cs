// Entity.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 07/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System;

namespace Chemtech.CPNM.Model.Domain
{
    public abstract class Entity : Entity<Guid>
    {
        public new virtual string ToString()
        {
            return Id.ToString();
        }
    }

    public abstract class NamedEntity : Entity, INamed
    {
        public virtual string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    internal interface INamed
    {
        string Name { get; set; }
    }

    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) && !IsTransient(other) && Equals(Id, other.Id))
            {
                Type otherType = other.GetUnproxiedType();
                Type thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        private static bool IsTransient(Entity<TId> obj)
        {
            return obj != null && Equals(obj.Id, default(TId));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(TId)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }
    }
}