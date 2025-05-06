using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Country
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Province> Provinces { get; private set; } = new();

        private Country() { }

        public Country(string name) => Name = name;

        public void AddProvince(string provinceName)
        {
            if (string.IsNullOrWhiteSpace(provinceName))
                throw new ArgumentException("Province name cannot be empty.");

            if (Provinces.Any(p => p.Name == provinceName))
                throw new InvalidOperationException($"Province '{provinceName}' already exists in '{Name}'.");

            Provinces.Add(new Province(provinceName, Id));
        }
    }
}
