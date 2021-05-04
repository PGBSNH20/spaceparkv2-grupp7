using System;
using Xunit;
using SpacePark2;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    public class UnitTest1
    {
        [Fact]
        public void GetPerson()
        {
            ISpaceTravellerRepository TestRepository = new SpaceTravellerRepoTest();
            var result = TestRepository.Get("Sam");
            Assert.NotNull((result.Id).ToString());
        }
    }
}
