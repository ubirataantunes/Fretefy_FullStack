using System;

namespace Fretefy.Test.Domain.Entities
{
    public class Cidade : IEntity
    {
        public Cidade()
        {
        
        }

        public Cidade(Guid id, string nome, string uf, double? latitude = null, double? longitude = null)
        {
            Id = id;
            Nome = nome;
            UF = uf;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void UpdateLatitudeAndLongitude(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public double? Latitude { get; private set; }
        public double? Longitude { get; private set; }

    }
}
