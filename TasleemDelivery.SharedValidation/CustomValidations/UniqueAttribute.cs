using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using TasleemDelivery.Data;

namespace TasleemDelivery.SharedValidation.CustomValidations
{
    public class UniqueAttribute : ValidationAttribute
    {
        private readonly Type _dbContextType;
        private readonly string _propertyName;

        public UniqueAttribute(Type dbContextType, string propertyName)
        {
            _dbContextType = dbContextType;
            _propertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Allow null values (if applicable)
            }

            var dbContext = (Context)validationContext.GetService(_dbContextType);

            // Get the value of the property using reflection
            var propertyInfo = validationContext.ObjectType.GetProperty(_propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{_propertyName}' not found on type '{validationContext.ObjectType.FullName}'.");
            }

            var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance);

            // Check if any other record with the same property value exists in the database
            var entityType = dbContext.Model.FindEntityType(validationContext.ObjectType);
            var keyProperty = entityType.FindPrimaryKey().Properties.FirstOrDefault();
            var keyName = keyProperty?.Name;

            // Use the correct DbSet<TEntity> syntax with reflection
            var dbSetType = dbContext.GetType().GetMethod("Set")?.MakeGenericMethod(validationContext.ObjectType);
            var dbSet = dbSetType?.Invoke(dbContext, null);

            if (dbSet is IQueryable<object> queryable)
            {
                if (queryable.Cast<object>()
                    .Any(x => !propertyValue.Equals(x.GetType().GetProperty(keyName).GetValue(x)) &&
                              propertyValue.Equals(x.GetType().GetProperty(_propertyName).GetValue(x))))
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be unique.");
                }
            }

            return ValidationResult.Success;
        }
    }
}









