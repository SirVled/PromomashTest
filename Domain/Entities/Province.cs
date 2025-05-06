using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Domain.Entities
{
    public class Province
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Country Country { get; private set; }
        public int CountryId { get; private set; }
        private Province() { }

        public Province(string name, int countryId) =>
            (Name, CountryId) = (name, countryId);
    }
}
