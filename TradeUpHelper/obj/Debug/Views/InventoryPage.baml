   M S B A M L   `   `   `  ����H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  5      C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  67   K*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  6q   '    !TradeUpHelper.Views.InventoryPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TradeUpHelper.Views     5      =
viewmodels&clr-namespace:TradeUpHelper.ViewModels     67   A
converters*clr-namespace:TradeUpHelper.DataConverters     6q     N� Title$  InventoryPage��5	       � 	Resources 5      5   /TradeUpHelper.DataConverters.ShortWearConverter   shortWearConverter �� MergedDictionaries �� Source�� 5   
    5      �� 5      $1 +/Resources/Styles/WindowControlButtons.xaml?�6%   �� 5      $, &/Resources/Styles/TextBoxesStyles.xaml?�6%   �� 5      $) #/Resources/Styles/LabelsStyles.xaml?�6%   �� 5      $* $/Resources/Styles/ButtonsStyles.xaml?�6%   �� 5      $0 */Resources/Styles/InventoryListStyles.xaml?�6%   �� 5      $+ %/Resources/Styles/MainMenuStyles.xaml?�6%   %   &	          5      6,   5       � DataContext 5      .  (TradeUpHelper.ViewModels.InventoryPageVM  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5!   
   �� 5"      $��80 �6   �� 5#      $��* �6   .+�5(   
   � $��0��6   $��0��6     Color_WindowBackground#���  6,    5)      �� 5*      $��* �6#   �� 5+      $��* �6#   �� 5,      $��* �6#    5.      �� 5/      $��30 �6    �� 50      $��* �6    �� 51      $��* �6    .+�57      ��  �� Orientation$ 
Horizontal=�6   $��1��62   $��0��6?   .+�58      ��    InventoryInventorySavingTime#���  6   
�������$��10(�6d   �� 59      
�������$��10(�6T   ��6   �� *InventoryLoadingDate+6T   5:      �� 5<      $ 
Horizontal=�6   $��2��62   $��0��6?   .+�5=      ��   InventoryPrice#���  6   
�������$��10(�6V   �� 5>       �� ContentStringFormat$
 {0}$��6;   
�������$��10(�6k   ��6   �� *InventoryPrice+6k   5?      �� 5A      $ 
Horizontal=�6   $��1��62   $��1��6?   .+�5B      ��   InventoryCount#���  6   
�������$��10(�6V   �� 5C      
�������$��10(�6N   ��6   �� *InventoryCount+6N   5D      �� 5F      $ 
Horizontal=�6   $��Right=�62   $��0��6N   $��2��6[   .+�5G      �� $��30��6?   $��30��6J   $��0,0,10,0q�6V     ScinOverlaySwitch#���  6h   ��6   �� *SwitchScinOverlay+6h   �� 5H      $��30��6=   $��30��6H   $��0,0,10,0q�6T     RefrashButton#���  6f   ��6   �� *UpdateInventory+6f   5J      5K      � 5M   
   $��2��6   $��0��6   
��� � �.+�5N      �  5O      ?  9TradeUpHelper.DataConverters.ContractResultColorConverter  ColorConverter7  1TradeUpHelper.DataConverters.RarityColorConverter  RarityColorConverter1  +TradeUpHelper.DataConverters.ImageConverter 	 ImageConverter��%W   &	       &	      &		 &       5P      6>     5Q      66     5R      60   5S       5T      �� 5U      $��* �6'   �� 5W      ��6'   �� *ScinOverlayWidth+.+�5Y      �� $��0��6   $��Disabled=�6*    
 Lststyle#��� 
 6�     Color_lb_Background#���  6�   	 �� SelectedItem	 6`   �� *SelectedItem+��6�   �� *Scins+��5Z      �� 5[      .R�5\      � 
 K� IsItemsHost
 .  � Orientation$ 
Horizontal=�6<   5]      5a      �� 5b      $��1��6   $��1q�6)   ��6=   �� *SelectedItem.rarity+ �� 	Converter# [ ._�5c      � #���  6    5d      �� 5e      $	��200 �6,   �� 5f      $��* �6,   �� 5g      $��* �6,   �� 5h      $��* �6,   �� 5i      $��* �6,   �� 5j      $��* �6,   �� 5k      $��* �6,   �� 5l      $��* �6,    5o      ��%W   &	       &	      &		 &       5p      6F     5q      6>     5r      68   5s      .+�5u      �� $��0��6    $��10,10,10,10q�6-   $��Stretch=�6�   $��Stretch=�6�   ��6B   �� *SelectedItem.imageurl+# [	 6�   �� 5x      $��1��6    
�������$��15(�6i   ��6-   �� *SelectedItem.GetName+6i   �� 5y      $��2��6    
�������$��12(�6�   ��6-   �� *SelectedItem.floatvalue+# [   �� ConverterParameter$
 long��6�   �� 5{      $ 
Horizontal=�6%   $��3��6>   .+�5|      ��  	 Float#���  6$   
�������$��12(�6Z   �� 5}      
�������$��12(�6c   ��6$   �� *SelectedItem.floatvalue+6c   5~      �� 5�      $ 
Horizontal=�6%   $��4��6>   .+�5�      ��   InventoryPattern#���  6$   
�������$��12(�6e   �� 5�      
�������$��12(�6b   ��6$   �� *SelectedItem.paintseed+6b   5�      �� 5�      $ 
Horizontal=�6%   $��5��6>   .+�5�      �� #���  6$   
�������$��12(�6c   �� 5�      $ {0:F2}$��6K   
�������$��12(�6~   ��6$   �� *SelectedItem.price+6~   5�      �� 5�      $ 
Horizontal=�6%   $��6��6>   .+�5�      ��   InventoryPriceClear#���  6$   
�������$��12(�6h   �� 5�      $ {0:F2}$��6S   
�������$��12(�6�   ��6$   �� *SelectedItem.GetClearPrice+6�   5�      �� 5�      $ 
Horizontal=�6%   $��7��6>   .+�5�      ��   InventoryStickers#���  6$   
�������$��10(�6e   5�      5�      5�      5�      5�      5�      5�      