   M S B A M L   `   `   `  ????G  CMyWpfProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MyWpfProject.View.MainView.ToDoListView'MyWpfProject.View.MainView.ToDoListView  5   	   >    8MyWpfProject.View.MainView.ToDoListView.EditMyTaskWindow   5   	   ?local5clr-namespace:MyWpfProject.View.MainView.ToDoListView  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   $	??556??5   	   $	??718??6     ? WindowStartupLocation$  CenterScreen=?5
   	    ? WindowStyle$
 None=?5   	    ? 
ResizeMode$ NoResize=?5   	   .??5      ? ???#1b191c ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      .+?5   
   ? -   5        $??0??5      ???#1b191c.+?5      ?? $??Right=?6    ?? Orientation$ 
Horizontal=?65   $??0??6N   $??2??6[   .+?5      ?? -   5        $??0q?5      $	??Top=?6/   $??Right=?6G   $??5q?6c   $??25??6n   $??25??6z    .  *MaterialDesignFloatingActionMiniDarkButton#??[  6?   .??5      ?? $A??;/images/7148710_minus_remove_delete_trash_collapse_icon.png??6   $??3q?6a   5      ?? 5      -   5        $??0q?5      $	??Top=?6/   $??Right=?6G   $??5q?6c   $??25??6n   $??25??6z   #??[  6?   .??5      ?? $8??2/images/4879885_close_cross_delete_remove_icon.png??6   $??3q?6X   5      5      5      ?? 5   
   $??
20 0 20 20q?6   ???#333333 ?? CornerRadius$ 20??6:   $??1??6M    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q?6$      Color$ Black??64   	   ShadowDepth$	 0Q?6B   ._?5!      ?? $??10q?6   .+?5"      ?? 
???????$-??'Редактировать задачу??60   $??30(?6L   $
??Bold"?6Z   
 ?? TextAlignment$
 Center=?6l   ?? 5#      -   5         ??Name$ titleTextBox??5#      
???????$??
50 20 50 0q?6C   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ заголовок??6W    % !MaterialDesignFloatingHintTextBox#??[ 6?   ?? 5$      -   5        $ descriptionTextBox??5$      
???????$??
50 20 50 0q?6I   $ описание??6]    ?? MaxLines$ 3??6?    ?? AcceptsReturn . #??[ 6?   ?? 5%      
???????$T??Nвыбирете предворительную дату завершения ??60   $??12(?6a   $

 Left=?6o   $??	50 40 0 0q?6?   (  "System.Windows.Controls.DatePicker  5&      -   5          Name$ deadLine??5&      $??50 10 430 0q?61   ?? 5'      -   5        $??
0 150 50 0q?5'      $??Right=?6-   $	??200??6I   $??изменить??6U   6h   5(      5)      5*      5+      