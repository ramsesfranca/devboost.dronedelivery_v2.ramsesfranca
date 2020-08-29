﻿using System;
using System.Collections.Generic;

namespace DroneDelivery.Domain.Entidades
{
    public class Cliente
    {
        private readonly IList<string> _roles = new List<string>();
        private readonly IList<string> _permissions = new List<string>();

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public IEnumerable<string> Roles => _roles;
        public IEnumerable<string> Permissions => _permissions;

        bool Validate()
        {
            return this.Nome == string.Empty || this.Senha == string.Empty;
        }
    }
}
