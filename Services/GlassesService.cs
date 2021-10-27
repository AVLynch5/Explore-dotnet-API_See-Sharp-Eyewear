using SeeSharp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeeSharp.Services
{
    public static class GlassesService
    {
        static List<Glasses> Glassess { get; }
        static int nextId = 3;
        static GlassesService()
        {
            Glassess = new List<Glasses>
            {
                new Glasses { Id = 1, Name = "Classic Italian", Color = "gold", Shape="circular" },
                new Glasses { Id = 2, Name = "Georgio Armani", Color = "silver", Shape="rectangular" }
            };
        }

        public static List<Glasses> GetAll() => Glassess;

        public static Glasses Get(int id) => Glassess.FirstOrDefault(p => p.Id == id);

        public static void Add(Glasses glasses)
        {
            glasses.Id = nextId++;
            Glassess.Add(glasses);
        }

        public static void Delete(int id)
        {
            var glasses = Get(id);
            if(glasses is null)
                return;

            Glassess.Remove(glasses);
        }

        public static void Update(Glasses glasses)
        {
            var index = Glassess.FindIndex(p => p.Id == glasses.Id);
            if(index == -1)
                return;

            Glassess[index] = glasses;
        }
    }
}