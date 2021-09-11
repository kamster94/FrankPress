namespace FrankPress.DataAccess.DataModels
{
    public class Role
    {
        private Role()
        {
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = null!;

        public static Role Create(
            int id,
            string name) =>
            new Role()
            {
                Id = id,
                Name = name
            };
    }
}
