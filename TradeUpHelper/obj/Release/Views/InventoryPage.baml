   M S B A M L   `   `   `  ���� H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  K*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  '    !TradeUpHelper.Views.InventoryPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:TradeUpHelper.Views     =
viewmodels&clr-namespace:TradeUpHelper.ViewModels     A
converters*clr-namespace:TradeUpHelper.DataConverters       N� Title$  InventoryPage�� � 	Resources 5   /TradeUpHelper.DataConverters.ShortWearConverter   shortWearConverter �� MergedDictionaries �� Source��  �� $1 +/Resources/Styles/WindowControlButtons.xaml?��� $, &/Resources/Styles/TextBoxesStyles.xaml?��� $) #/Resources/Styles/LabelsStyles.xaml?��� $* $/Resources/Styles/ButtonsStyles.xaml?��� $0 */Resources/Styles/InventoryListStyles.xaml?��� $+ %/Resources/Styles/MainMenuStyles.xaml?�%   &	           � DataContext .  (TradeUpHelper.ViewModels.InventoryPageVM  .���  � ColumnDefinitions �� $��* � � RowDefinitions �� $��80 ��� $��* �.+�� $��0��$��0��  Color_WindowBackground#���   �� $��* ��� $��* ��� $��* � �� $��30 ��� $��* ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��1��$��0��.+���    InventoryInventorySavingTime#���  
�������$��10(��� 
�������$��10(����� *InventoryLoadingDate+�� $ 
Horizontal=�$��2��$��0��.+���   InventoryPrice#���  
�������$��10(���  �� ContentStringFormat$
 {0}$��
�������$��10(����� *InventoryPrice+�� $ 
Horizontal=�$��1��$��1��.+���   InventoryCount#���  
�������$��10(��� 
�������$��10(����� *InventoryCount+�� $ 
Horizontal=�$��Right=�$��0��$��2��.+��� $��30��$��30��$��0,0,10,0q�  ScinOverlaySwitch#���  ���� *SwitchScinOverlay+�� $��30��$��30��$��0,0,10,0q�  RefrashButton#���  ���� *UpdateInventory+� $��2��$��0��
��� � �.+��  ?  9TradeUpHelper.DataConverters.ContractResultColorConverter  ColorConverter7  1TradeUpHelper.DataConverters.RarityColorConverter  RarityColorConverter1  +TradeUpHelper.DataConverters.ImageConverter 	 ImageConverter��%-   &	       &	      &		 
            �� $��* ��� ���� *ScinOverlayWidth+.+��� $��0��$��Disabled=� 
 Lststyle#��� 
   Color_lb_Background#���  	 �� SelectedItem	 �� *SelectedItem+���� *Scins+���� .R�� 
 K� IsItemsHost
 .  � Orientation$ 
Horizontal=��� $��1��$��1q����� *SelectedItem.rarity+ �� 	Converter# [ ._�� #���   �� $	��200 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � ��%-   &	       &	      &		 
           .+��� $��0��$��10,10,10,10q�$��Stretch=�$��Stretch=����� *SelectedItem.imageurl+# [	 �� $��1��
�������$��15(����� *SelectedItem.GetName+�� $��2��
�������$��12(����� *SelectedItem.floatvalue+# [   �� ConverterParameter$
 long���� $ 
Horizontal=�$��3��.+���  	 Float#���  
�������$��12(��� 
�������$��12(����� *SelectedItem.floatvalue+�� $ 
Horizontal=�$��4��.+���   InventoryPattern#���  
�������$��12(��� 
�������$��12(����� *SelectedItem.paintseed+�� $ 
Horizontal=�$��5��.+��� #���  
�������$��12(��� $ {0:F2}$��
�������$��12(����� *SelectedItem.price+�� $ 
Horizontal=�$��6��.+���   InventoryPriceClear#���  
�������$��12(��� $ {0:F2}$��
�������$��12(����� *SelectedItem.GetClearPrice+�� $ 
Horizontal=�$��7��.+���   InventoryStickers#���  
�������$��10(�