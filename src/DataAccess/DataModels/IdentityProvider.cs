namespace FrankPress.DataAccess.DataModels
{
    public class IdentityProvider : BaseDataModel
    {
        private IdentityProvider()
        {
        }

        public string Name { get; private set; } = null!;

        public static IdentityProvider Create(
            int? id,
            string name) =>
            new IdentityProvider()
            {
                Id = id,
                Name = name
            };
    }
}
