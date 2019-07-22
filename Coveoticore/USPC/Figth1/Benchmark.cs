using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Coveoticore.Benchmarks.Logger;
using Coveoticore.Benchmarks.USPC.Octagon;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.HttpRequest;

namespace Coveoticore.Benchmarks.USPC.Figth1
{
    public class Benchmark : HttpRequestProcessor
    {
        private const string ROOT_ITEM_ID = "{200F1080-5FB2-4873-B4D4-C003354F4D57}";

        public override void Process(HttpRequestArgs args)
        {
            var master = Sitecore.Configuration.Factory.GetDatabase("master");

            if (master != null)
            {
                FightNightEvent fightNightEvent = new FightNightEvent
                {
                    Name = "USPC Fight 1",
                    Rounds = 5,
                    BlueCornerContender = new Contender
                    {
                        Name = "Item.Axes.GetDescendants()",
                        Action = () => { ItemAxesGetDescendants(master); }
                    },
                    RedCornerContender = new Contender
                    {
                        Name = "Item.GetChildren()",
                        Action = () => { ItemGetChildren(master); }
                    }
                };

                Executer bruceBuffer = new Executer(fightNightEvent);

                bruceBuffer.LetsGetItOn();
            }
        }

        private void ItemAxesGetDescendants(Database p_Database)
        {
            IList<Item> kids = p_Database.GetItem(ROOT_ITEM_ID).Axes.GetDescendants().ToList();
        }

        private void ItemGetChildren(Database p_Database)
        {
            IList<Item> kids = ItemGetChildren(p_Database.GetItem(ROOT_ITEM_ID)).ToList();
        }

        private IEnumerable<Item> ItemGetChildren(Item p_Item, bool p_ReturnRootItem = false)
        {
            if (p_ReturnRootItem)
            {
                yield return p_Item;
            }

            foreach (Item child in p_Item.GetChildren(ChildListOptions.SkipSorting))
            {
                foreach (Item subChild in ItemGetChildren(child, true))
                {
                    yield return subChild;
                }
            }
        }
    }
}