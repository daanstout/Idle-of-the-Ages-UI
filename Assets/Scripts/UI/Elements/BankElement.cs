using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI {
    [UIElement(typeof(IBankElement))]
    public class BankElement : Element<Box, object>, IBankElement{

    }
}
