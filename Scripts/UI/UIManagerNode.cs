using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAges.Scripts.UI;

public partial class UIManagerNode : Node {
    [Export] private Panel headerPanel;
    [Export] private Panel footerPanel;
    [Export] private Panel tabListPanel;
    [Export] private Panel mainUIPanel;
}
