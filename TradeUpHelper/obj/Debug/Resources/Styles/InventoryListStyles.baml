   M S B A M L   `   `   `  ����H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  5   L   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Lststyle  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources?   9TradeUpHelper.DataConverters.ContractResultColorConverter  Key7  1TradeUpHelper.DataConverters.RarityColorConverter1  +TradeUpHelper.DataConverters.ImageConverter  Color_lb_buttonBackground �� Padding �� CornerRadius � RowDefinitions  ImageConverter �� 	Converter	 �� Orientation 	 Float
 �� ContentStringFormat 	 Price  RarityColorConverter �� Triggers P� Property P� Value �� 
TargetName  Color_lb_buttonBorderFocus " Color_lb_buttonBackgroundFocus�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      9
converters*clr-namespace:TradeUpHelper.DataConverters  6L   %:  &	        7  7  �� 5      "  ��6   .�5   
   ��  � ��$ 
10,10,10,0q�6#   �� 5   
    � ��
 ���� 6'   �� 5   
    � �� 5      �� 5	      " ��6"    5
      ��   5      ColorConverter 6B     5      RarityColorConverter 6:     5      ImageConverter 64   5      .R�5      �� $��Border��6   #���  6+   $ 7q�6d   $��5,0,5,0q�6p   $	��150��6�   $	��120��6�   $��1,1,1,1q�6�   
�������$ 1��6�   ._�5      �  5      �� 5   "   $��80 �60   �� 5   "   $��* �60   �� 5   "   $��* �60   �� 5   "   $��5 �60   .+�5      �� $��0��6$   $��0,0,0,0q�6y   $��Stretch=�6�   $��Stretch=�6�   ��61   �� *
imageurl+8   6�   �� 5      $��1��6)   $	 
Horizontal=�66   .+�5   "   �� #���  6(   
�������6J   �� 5   "   $
 {0:F8}��6H   
���������6(   �� *
floatvalue+6g   5      �� 5      $��2��6)   $	 
Horizontal=�66   .+�5   "   �� #���  6(   
�������6J   �� 5    "   $

 {0}$��6C   
���������6(   �� *price+6`   5!      �� 5"      $��2��6$   �� 5#      $��3��6(   $��Stretch=�65   $��Stretch=�6S   ��6o   �� *rarity+8  5$      5%       5(      P� 5)       �@J�IsMouseOver . . �5*      �� $ Border��6%   # �  6P    � ���� 5+      $ Border��6%   # �  6O    � ��5,      P� 5-       �@��
IsSelected . . �5.      �� $ Border��6%   # �  6P    � ���� 5/      $ Border��6%   # �  6O    � ��50      53      55      57      58      