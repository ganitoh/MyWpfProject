   M S B A M L   `   `   `  ????G  CMyWpfProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:MyWpfProject.View.MainView.MyFinanceView(MyWpfProject.View.MainView.MyFinanceView  5   	   ?    9MyWpfProject.View.MainView.MyFinanceView.AddPurposeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   Blocal6clr-namespace:MyWpfProject.View.MainView.MyFinanceView  5   	     ? Title$  AddPurposeWindow??5	   	   $	??400??6"   $	??500??6/    ? WindowStyle$
 None=?5
   	    ? 
ResizeMode$ NoResize=?5   	   .??5      ? ???#1b191c ? RowDefinitions 5   
   ?? 5      $??70 ?6   ?? 5      .+?5   
   ? -   5        ???#1b191c ? ColumnDefinitions 5      ?? 5      ?? 5      $	??100 ?6#   .+?5      ?? -   5        $??35??5      $	??280??6!    ?? CornerRadius$ 10??6-   ???	#FF673AB7$??2??6V   ._?5      ?? 
???????$??Center=?60   $??Center=?6K   $??добавить цель??6h   $??24(?6}   5      ?? 5      -   5        $??0q?5      $??1??6)   $	??Top=?6:   $??Right=?6R   $??0 5 30 0q?6n   $??20??6?   $??20??6?    .  *MaterialDesignFloatingActionMiniDarkButton#??[  6?   .??5      ?? $A??;/images/7148710_minus_remove_delete_trash_collapse_icon.png??6   $??3q?6]   5      ?? 5      -   5        $??0q?5      $??1??6)   $	??Top=?6:   $??Right=?6R   $??5q?6n   $??20??6y   $??20??6?   #??[  6?   .??5      ?? $8??2/images/4879885_close_cross_delete_remove_icon.png??6   $??3q?6T   5       5!      ?? 5"   
   -   5         ??Name$ mainStackPanel??5"       ?? Orientation$ Vertical=?6-   $??1??6D   .+?5#      ?? -   5         ??Name$ titleTextBox??5#      $??
50 10 50 0q?6,   
???????)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 заголовок??6S   ?? 5$      -   5        $ discriptionTextBox??5$      $??
50 30 50 0q?62   
???????$	 описание??6Y   ?? 5%      -   5        $ finalAmountMonyTextBox??5%      $??
50 30 50 0q?66   
???????$#	 финальная сумма??6]   ?? 5&      -	   5        $  collectedAmountMonyTextBox??5&      $??
50 30 50 0q?6:   
???????$R	 Lсобранная сумма (если уже что-то собранно)??6a   ?? 5'      -
   5        
 ??Name$
 isMainPurposesCheckBox??5'      $??
50 10 50 0q?67   $??основная цель??6K   
??????? 2 .MaterialDesignFilterChipPrimaryOutlineCheckBox#??[ 6u   ?? 5(      -   5        $??
0 30 50 10q?5(      $	??150??6)   $??Right=?65   $??добавить??6Q   6d   5)      5*      5+      