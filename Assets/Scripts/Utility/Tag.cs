using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Assets
{
    public class Tag
    {
        private static string EnemyTag = "Enemy";
        private static string BaseTag = "Base";

        public static string Enemy { get { return EnemyTag; }}
        public static string Base { get { return BaseTag; } }
    }
}
