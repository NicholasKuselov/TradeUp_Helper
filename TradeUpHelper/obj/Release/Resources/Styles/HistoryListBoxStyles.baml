   M S B A M L   `   `   `  ���� H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Lststyle  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources?   9TradeUpHelper.DataConverters.ContractResultColorConverter  Key7  1TradeUpHelper.DataConverters.RarityColorConverter1  +TradeUpHelper.DataConverters.ImageConverter  Color_lb_buttonBackground �� Padding �� CornerRadius  ColorConverter �� 	Converter � ColumnDefinitions  RarityColorConverter  ImageConverter		 �� X1	
 �� Y1	 �� X2	 �� Y2  Color_lb_devider �� Stretch  HistoryItemPrice  Color_lb_buttonText �� StringFormat �� ConverterCulture 	 HistoryItemOutcomePrice 
 HistoryItemFloat  HistoryItemProfitClear  HistoryItemDate �� Triggers P� Property P� Value �� Triggers�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     9
converters*clr-namespace:TradeUpHelper.DataConverters  %{	  &	        7  7  7  7  �� "  ��.���  � ��$ 
10,10,10,0q���  � ��
 ���� ��  � �� �� " �� ��   ColorConverter   RarityColorConverter   ImageConverter .R��� $��Border��#���  $ 1q�$��3,0,0,0q�$ 1������ *getClearProfit+8   ._��  �� $��20 ��� $��80 ��� $��* ��� $	��160 ��� $��* ��� $	��130 ��� $��* ��� $��* �.+�� $��0��.+�A� $��6��$��6��$��Center=�$��Center=����� *rarity+8  ���� *rarity+8  � $��1��.+��� $��50��$��80��$��0,0,0,0q�$��Center=�$
��Left=����� *
imageUrl+8  � $��2��.+��� $��Center=�$
��Left=�
�������$��14(����� *	getName+� $��3�� �� $	��115 ��� $��* �.+��� $	 0��$
 0��$ 0��$ 30��#���  $��2��$
��Left=�$
 Fill=�$��0,0,0,0q��� $��0��#���  $��Center=�$��Center=�
������ #���  �� $��1��$
��Left=�$��Center=�
������ #���  ���� *price+$
 0.00��$ ru-Ru��� $��4�� �� $	��100 ��� $��* �.+��� $	 0��$
 0��$ 0��$ 30��#���  $��2��$
��Left=�$
 Fill=�$��0,0,0,0q��� $��0��#��� 	 $��Center=�$��Center=�
������ #���  �� $��1��$
��Left=�$��Center=�
������ #���  ���� *outcomePrice+$
 0.00��$ ru-Ru��� $��5�� �� $��50 ��� $��* �.+��� $	 0��$
 0��$ 0��$ 30��#���  $��2��$
��Left=�$
 Fill=�$��0,0,0,0q��� $��0��#��� 
 $��Center=�$��Center=�
������ #���  �� $��1��$
��Left=�$��Center=�
������ #���  ���� *
resFloat+$
 0.00��$ ru-Ru��� $��6�� �� $��90 ��� $��* �.+��� $	 0��$
 0��$ 0��$ 30��#���  $��2��$
��Left=�$
 Fill=�$��0,0,0,0q��� $��0��#���  $��Center=�$��Center=�
������ #���  �� $��1��$
��Left=�$��Center=�
������ #���  ���� *getClearProfit+$
 0.00��$ ru-Ru��� $��7�� �� $��50 ��� $��* �.+��� $	 0��$
 0��$ 0��$ 30��#���  $��2��$
��Left=�$
 Fill=�$��0,0,0,0q��� $��0��#���  $��Center=�$��Center=�
������ #���  �� $��1��$
��Left=�$��Center=�
������ #���  ���� *date+$
 0.00��$ ru-Ru�� P�  �@J�IsMouseOver . P�  �@��
IsSelected .  P�  �@J�IsMouseOver . . ���  � ��$ 2,10,2,2q�P�  �@��
IsSelected . . ���  � ��$ 2,10,2,2q�