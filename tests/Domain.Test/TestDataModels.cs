using FrankPress.DataAccess.DataModels;

namespace FrankPress.Domain.Test
{
    internal static class TestDataModels
    {
        internal static Role GetMockedRole()
        {
            return Role.Create(
                1,
                "testName");
        }

        internal static IdentityProvider GetMockedIdentityProvider()
        {
            return IdentityProvider.Create(
                1,
                "testName");
        }

        internal static User GetMockedUser()
        {
            return User.Create(
                1,
                "email",
                "name",
                "lastName",
                "displayName",
                GetMockedRole(),
                GetMockedIdentityProvider(),
                false);
        }
    }
}
