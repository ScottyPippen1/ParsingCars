   M S B A M L   `   `   `  ����F  BParsingCars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ParsingCarsParsingCars  5   	       ParsingCars.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ParsingCars     5   	     � Title$
  Cars��5   	   $	��215��6   $	��500��6#   $	��215��6/   $	��500��6?    � 
ResizeMode$ 	CanResize=�6N   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   c� $	��Top=�6   $��0��6*   $��2��67   .@�5      o� .@�5      m� $
��Edit��6   .@�5      m� -   5        $��Add Vehicle��5      64   m� 5      -   5        $��Remove Vehicle��5      67   5      5      5      �� 5   
   -   5         ��Name$ dropDownList��5      $��Stretch=�6)   $��63,60,63,10q�6G   $	��Top=�6\   $��0��6t   $��0��6�    �� 
IsEditable . 6�   �� 5   
   -   5         ��Name$ buttonOk��5      $��Ok��6#   $
��Left=�60   $��	10,60,0,0q�6K   $	��Top=�6^   $��75��6v   $��0��6�   $��1��6�   6�   �� 5   
   $��Model��6   $��Center=�6    $	��Top=�6=   $��1��6U   $��0��6b   �� 5   
   -   5         ��Name$ searchResults��5      $��Stretch=�6)   $��10,20,10,10q�6G   $	��Top=�6\   $��1��6t   $��0��6�   5      �� 5   
   $��Details��6   $��Center=�6"   $	��Top=�6?   $��1��6W   $��1��6d   �� 5    
   -   5        $ modelDetails��5       $��Stretch=�6(   $��50,20,10,10q�6F   $	��Top=�6[   $��1��6s   $��1��6�   5!      �� 5"   
   $��Engine: ��6   $
��Left=�6#   $��0,20,0,0q�6>   $	��Top=�6P   $��1��6h   $��1��6u   �� 5#   
   $��MPG: ��6   $
��Left=�6    $��0,40,0,0q�6;   $	��Top=�6M   $��1��6e   $��1��6r   �� 5$   
   $
��Make��6   $��Center=�6   $��
95,30,95,0q�6<   $	��Top=�6P   5&      5'      