namespace FrankPress.DataAccess.DataModels
{
    public class Role : BaseDataModel
    {
        private Role()
        {
        }

        public string Name { get; private set; } = null!;

        public static Role Create(
            int? id,
            string name) =>
            new Role()
            {
                Id = id,
                Name = name
            };
    }
}
