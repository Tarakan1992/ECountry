using ECountry.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ECountry.Infrastructure
{
    public class SGuidValueGenerator : ValueGenerator<SGuid>
    {
        public override SGuid Next(EntityEntry entry)
        {
            return SGuid.New();
        }

        public override bool GeneratesTemporaryValues => false;
    }
}
