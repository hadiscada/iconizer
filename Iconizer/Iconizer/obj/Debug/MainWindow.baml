   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?Iconizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:IconizerIconizer 5   	      Iconizer.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   "localclr-namespace:Iconizer  5   	     � Title$  iconizer��5
   	   $	��550��6   $	��800��6'    � Icon$ icon_info.ico��63    � 	Resources 5       S� ObjectInstance!  System.Windows.Media.Colors S� 
MethodName   colorPropertiesOdp��%@   &	        S� 5   
   "  6   $ GetProperties��6>   6Y   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      �� 5      $��70 �6    .+�5      �� $��Designer��6   $	��0,0q�6)   .��5      �� .+�5      �� -   5        $��	cboParent��5   �   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Parent��6    �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 6M   .@�5      �� 	 �� 
IsSelected	 . .��69   None5      �� 5      	 .  .��6:   Button5       5!      �� 5"      -   5        $��cboParentStyle��5"   �   $ Parent Style��6    . #��[ 6S   .@�5#      �� 	 . .��69   None5%      �� 5&      	 .  .��6:   Circle5(      5)      �� 5*      -   5        $��txtParWidth��5*   �   $ Parent Width��6    % !MaterialDesignFloatingHintTextBox#��[ 6@   $�� ��6{   6�   �� 5+      -   5        $��txtParHeight��5+   �   $ Parent Height��6   #��[ 6A   $�� ��6|   6�   �� 5,      -   5        $��cboParColor��5,   A   $ Parent Color��6    . #��[ 6f   
 �� DisplayMemberPath$

 Name��6�    �� SelectedValuePath$
 Name��6�   ��6�   ��  �� Source# [  6�   ]� 5.      .+�5/      �� -   5        $��btnBrowseIcon��5/   8   $��Right=�6!   .��6i   ...6n   �� 50      -   5        $��txtIconKind��50   �   $ 	Icon Kind��6"   #��[ 6A   $
��Home��6|   6�   51      �� 52      -   5        $��txtIconWidth��52   �   $ 
Icon Width��6   #��[ 6>   $��50��6y   6�   �� 53      -	   5        $��txtIconHeight��53   �   $ Icon Height��6   #��[ 6?   $��50��6z   6�   �� 54      -
   5        $��cboIconColor��54   ?   $ 
Icon Color��6    �� Text$ CornflowerBlue��6S    . #��[ 6{   $

 Name��6�   $
 Name��6  ��6�   �� # [  6  �� 59      -   5        $��cboBackColor��59   E   $ Background Color��6    . #��[ 6k   $

 Name��6�   $
 Name��6  ��6�   �� # [  6  5;      5<      �� 5=       �� Orientation$ 
Horizontal=�6   $��1��62   $��Center=�6?   .+�5>      �� -   5        $��	btnCreate��5>      .��6B   Create6J   �� 5?      -   5        $��
btnSavePng��5?      $
��10,0q�6A   .��6O   
Save PNG6Y   �� 5@      -   5        $��
btnSaveIco��5@      .��6D   
Save ICO6N   5A      5B      �� 5C   
   $��2��6   
�������6!   � 5D   
   -   5        $��grdBack��5D      $��1��6   .+�5E      �� -   5        $��pnlObj��5E   Q   $��Center=�6   $��Center=�64   .+�5F      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��iconOnly��5F   ]      Kind$
 Home=�6   $��50��6*   $��50��65   
����d�$y�Visible=�6m   �� 5G      -   5        $��	btnCircle��5G   p    * &MaterialDesignFloatingActionMiniButton#��[ 6   $��50��6Y   $��50��6d   $y�	Collapsed=�6�   .��5H        -   5        $��
iconCircle��5H   X   $
 Home=�6"   $��30��6.   $��30��69   
�������6X   5I      �� 5J      -   5        $��	btnSquare��5J   <   $��50��6   $��50��6$   $��0q�60   $y�	Collapsed=�6M   .��5K        -   5        $��
iconSquare��5K   X   $
 Home=�6"   $��30��6.   $��30��69   
�������6X   5L      5M      5N      � 5O   
   -   5        $��grdIcons��5O   1   $��1��6   
�������$y�	Collapsed=�6A   .+�5P      �� $��Select Icon��6   $��50q�6,   
�������.��5Q      �� -   5        $��lsvIcons��5Q   :   $	��Top=�6   5]      5^      �� 5_      $ 
Horizontal=�6   $��50q�62   $	��Top=�6>   $��Right=�6V   .+�5`      �� -   5        $��btnPrevIcons��5`   $   $��30��6   
������ 
������ $��0q�6�   .��5a        $ 	ArrowLeft=�6"   5b      �� 5c      -   5        $��btnNextIcons��5c   $   $��30��6   
������ 
������ $��0q�6�   .��5d        $ 
ArrowRight=�6"   5e      �� 5f      -   5        $��txtFindIcon��5f   �   $	��100��6   $ Search��6&    �� TextAlignment$ Center=�6B   $��Center=�6Y   
�������6�   �� 5g      -   5        $��btnFindIcons��5g   $   $��30��6   
������ 
������ $��0q�6�   .��5h        $ Search=�6"   5i      �� 5j      -   5        $��btnCloseIcon��5j   $   $��50��6   
������ 
������ .��5k        $ Close=�6"   5l      5m      5n      � 5o   
   -   5        $��	grdColors��5o   1   $��1��6   
�������$y�	Collapsed=�6B   .+�5p      �� $��Select Color��6   $��50q�6-   
�������.��5q      �� -   5        $��	lsvColors��5q   :   $	��Top=�6   5r      5s      �� 5t      $ 
Horizontal=�6   $��50q�62   $	��Top=�6>   $��Right=�6V   .+�5u      �� -   5        $��btnCloseColor��5u   $   $��50��6   
������ 
������ .��5v        $ Close=�6"   5w      5x      5y      5z      5{      