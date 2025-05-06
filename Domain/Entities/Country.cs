using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Domain.Entities
{
    public class Country
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<Province> _provinces = new();
        public IReadOnlyCollection<Province> Provinces => _provinces.AsReadOnly();

        private Country() { }

        public Country(string name) => Name = name;

        public void AddProvince(string provinceName)
        {
            if (string.IsNullOrWhiteSpace(provinceName))
                throw new ArgumentException("Province name cannot be empty.");

            if (Provinces.Any(p => p.Name == provinceName))
                throw new InvalidOperationException($"Province '{provinceName}' already exists in '{Name}'.");

            _provinces.Add(new Province(provinceName, Id));
        }
    }
}
