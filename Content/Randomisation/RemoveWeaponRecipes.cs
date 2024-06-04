using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using static badgatchagame.Content.Randomisation.RandomItemsLists;

namespace badgatchagame.Content.Randomisation
{
    public class RemoveWeaponRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            List<int> allItemsToRemove = getAllRandomItems();
            for (int i = 0; i < Recipe.numRecipes; i++) {
                Recipe recipe = Main.recipe[i];
                for (int ii = 0; ii < allItemsToRemove.Count; ii++) {
                    if (recipe.HasResult(allItemsToRemove[ii])) {
                        recipe.DisableRecipe();
                    }
                }
            }

            base.PostAddRecipes();
        }
    }
}