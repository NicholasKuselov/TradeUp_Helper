   M S B A M L   `   `   `  ���� H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Lststyle  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources?   9TradeUpHelper.DataConverters.ContractResultColorConverter  Key7  1TradeUpHelper.DataConverters.RarityColorConverter1  +TradeUpHelper.DataConverters.ImageConverter  Color_lb_buttonBackground �� Padding �� CornerRadius � RowDefinitions  ImageConverter �� 	Converter	 �� Orientation 	 Float
 �� ContentStringFormat 	 Price  RarityColorConverter �� Triggers P� Property P� Value �� 
TargetName  Color_lb_buttonBorderFocus " Color_lb_buttonBackgroundFocus�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     9
converters*clr-namespace:TradeUpHelper.DataConverters  %�  &	        7  7  �� "  ��.���  � ��$ 
10,10,10,0q���  � ��
 ���� ��  � �� �� " �� ��   ColorConverter   RarityColorConverter   ImageConverter .R��� $��Border��#���  $ 7q�$��5,0,5,0q�$	��150��$	��120��$��1,1,1,1q�
�������$ 1��._��  �� $��80 ��� $��* ��� $��* ��� $��5 �.+��� $��0��$��0,0,0,0q�$��Stretch=�$��Stretch=����� *
imageurl+8   �� $��1��$	 
Horizontal=�.+��� #���  
��������� $
 {0:F8}��
����������� *
floatvalue+�� $��2��$	 
Horizontal=�.+��� #���  
��������� $

 {0}$��
����������� *price+�� $��2���� $��3��$��Stretch=�$��Stretch=����� *rarity+8   P�  �@J�IsMouseOver . . ��� $ Border��# �   � ���� $ Border��# �   � ��P�  �@��
IsSelected . . ��� $ Border��# �   � ���� $ Border��# �   � ��