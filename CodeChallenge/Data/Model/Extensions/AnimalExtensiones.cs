namespace CodeChallenge.Data.Model.Extensions
{
    public static class AnimalExtensiones
    {
        public static bool EsCarnivoro(this Animal animal)
            => animal.GetType() == typeof(Carnivoro);

        public static bool EsHerviboro(this Animal animal)
            => animal.GetType() == typeof(Hervivoro);

        public static bool EsReptil(this Animal animal)
            => animal.GetType() == typeof(Reptil);
    }
}
