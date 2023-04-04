using DDD.Library.ValueObjects;

namespace DDD.Library.Helpers
{
	public static class ObjectHelper
	{
        public static bool IsValueObject(object obj)
        {

           if (obj is null) throw new NullReferenceException("Obj cannot be null");

            var entityType = typeof(ValueObject<>).Name;
            var objectType = obj.GetType()?.BaseType?.Name;

            Console.WriteLine($"Entity Type: {entityType}");
            Console.WriteLine($"OBJ Type: {objectType}");

            return typeof(ValueObject<>).Name == obj.GetType()?.BaseType?.Name;
        }


        public static bool IsEntity(object obj)
        {
            if (obj is null) throw new NullReferenceException("Obj cannot be null");

            var entityType = typeof(Entity).Name;
            var objectType = obj.GetType()?.BaseType?.Name;

            Console.WriteLine($"Entity Type: {entityType}");
            Console.WriteLine($"OBJ Type: {objectType}");

            return entityType == objectType;                       

        }

    }
}

