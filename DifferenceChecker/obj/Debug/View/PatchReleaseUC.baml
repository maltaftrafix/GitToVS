   M S B A M L   `   `   `  ����T  PTrafix.Client.Controls, Version=1.5.0.1026, Culture=neutral, PublicKeyToken=null_Dclr-namespace:Trafix.Client.Controls;assembly=Trafix.Client.ControlsTrafix.Client.Controls  5   	   L HDifferenceChecker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DifferenceChecker.ViewDifferenceChecker.View 5   	   +   %DifferenceChecker.View.PatchReleaseUC   5      S
SKControlsDclr-namespace:Trafix.Client.Controls;assembly=Trafix.Client.Controls  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.2, Version=16.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DifferenceChecker.View     5   	   .��5	      � $��10,10,10,10q�6     � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $
��auto �6   .+�5   
   $   Trafix.Client.Controls.SKLabel  $��Base Source��6   $��0��63   $��0��6@   $��Center=�6P   �� 5   
   -   5         ��Name$ urlPath1��5   ;   $��0��6   $��1��6   $��25��6/   $
��auto��6M   {�.  6n     5    
   $��1��6   $��0��6*   $��App Type��6:   $��Center=�6M   '   !Trafix.Client.Controls.SKComboBox  5!   
   -   5          Name$ baseDirectory��5!   V   $��25��6    $��1��6,   $��1��69   $
��auto��6I      
isEditable .  6�     5#   
   $��2��6   $��0��6*   $��Release Directory��6:   $��Center=�6V     5$   
   -   5        $ releaseDirectory��5$   V   $��25��6    $��2��6,   $��1��69   $
��auto��6I    .  6�     5&   
   $��3��6   $��0��6*   $��Working Directory��6:   $��Center=�6V   &    Trafix.Client.Controls.SKTextBox  5'   
   -   5          Name$ workingDirectory��5'   U   $��25��6   $��3��6+   $��1��68   $
��auto��6H   6U     5)   
   $��4��6   $��0��6*   $��Description��6:   $��Center=�6P     5*   
   -   5        $ description��5*   U   $��25��6   $��4��6+   $��1��68   $
��auto��6H   6U     5,   
   $��5��6   $��0��6*   $��Additional Params��6:   $��Center=�6V     5-   
   -   5        $ additionalParams��5-   U   $��25��6   $��5��6+   $��1��68   $
��auto��6H   6U     53   
   $��6��6   $��0��6*   $��Environment��6:   $��Center=�6P   � 54   
   $��6��6   $��1��6!   $
��Left=�61   .+�55      '   !Trafix.Client.Controls.SKCheckBox  -   5          Name$ 
chkboxDemo��55   3   &   DevExpress.Xpf.Editors.CheckEdit   Content)  #DevExpress.Xpf.Core.ObjectConverter$
 Demo 6$   $��70��6G     56      -   5        $ chkboxQA��56   B      	IsChecked$
 TrueY�6$   $ QA 65   $��70��6T     57      -	   5        $ 	chkboxUAT��57   2   $	 UAT 6$   $��70��6E     58      -
   5        $ 
chkboxLIVE��58   9   $ 
Production 6$   69   59      � 5:   
   $��6��6   $��1��6!   $��Right=�61   .+�5;        -   5        $ chkboxOverwrite��5;   I   $ 	Overwrite 6$   $
 TrueY�68   $��Right=�6b   5<        5>   
   $��7��6   $��0��6*   $��Executables��6:   $��Center=�6P   � 5?   
   -   5        	 �Name$	 customChkBox��5?      $��7��6*   $��1��67   $
��auto��6G   $
��Left=�6U   5C      �� 5H   
   -   5        
 ��Name$
 Transfer��5H   .   $��8��6   $��1��6   $��30��6@   $	��100��6L   $��UPLOAD��6X   $��15(�6i   $��Right=�6�   6�   �� 5J   
   -   5         ��Name$ 	statusBox��5J   �   
�������$��14(�6,    �� 
LineHeight$ 2��6:   $��9��6O   $��1��6\   $	��250��6l   $
��Auto��6y    �� 
IsReadOnly . $ �� HorizontalScrollBarVisibility$
 Auto=�6�   5M      5N      