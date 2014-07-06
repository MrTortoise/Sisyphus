using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using Sisyphus.Core.Model;
    using Sisyphus.Web.Controllers;

    [Binding]
    public class CharacterBrowserSteps
    {
        [Given(@"I create the following characters")]
        public void GivenICreateTheFollowingCharacters(Table table)
        {
            var controller = new CharacterEditorController();
            foreach (TableRow tableRow in table.Rows)
            {
                var name = tableRow[0];
                var backStory = tableRow[1];
                var race = tableRow[2];
                var sex = tableRow[3];
                var place = tableRow[4];

                controller.CreateCharacter(name, backStory, race, sex, place);
            }
        }
    }
}
