   M S B A M L   `   `   `  ����H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  5      C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  67   K*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  6q   +    %TradeUpHelper.Views.MarketCheckerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TradeUpHelper.Views     5      =
viewmodels&clr-namespace:TradeUpHelper.ViewModels     67   A
converters*clr-namespace:TradeUpHelper.DataConverters     6q   -   5          N� Title$  MarketCheckerPage��5	       � 	Resources 5      5   /TradeUpHelper.DataConverters.ShortWearConverter   shortWearConverter �� MergedDictionaries �� Source�� 5   
    5      �� 5      $1 +/Resources/Styles/WindowControlButtons.xaml?�6%   �� 5      $, &/Resources/Styles/TextBoxesStyles.xaml?�6%   �� 5      $) #/Resources/Styles/LabelsStyles.xaml?�6%   �� 5      $* $/Resources/Styles/ButtonsStyles.xaml?�6%   �� 5      $+ %/Resources/Styles/MainMenuStyles.xaml?�6%   �� 5      $4 ./Resources/Styles/MarketCheckerListStyles.xaml?�6%   %   &	          5      6,   5       � DataContext 5      2  ,TradeUpHelper.ViewModels.MarketCheckerPageVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��14 �6   �� 5       $��40 �6   �� 5!      $��* �6   �� 5"      $��30 �6   .+�5%   
   ��   Color_WindowBackground#���  6   $��0��6G   $��10(�6U   $��Stretch=�6c   $��Center=�6�   $��0,0,0,0q�6�   $��0,0,0,0q�6�     MCSIHWarning#���  6�   
�������6�   � 5(   
   $��1��6   #���  6   .+�5)      �� $
��Left=�6    �� Orientation$ 
Horizontal=�64   .+�5*      �� $	��300��60   $��26��6<     SIH_Page#���  6H    �� TextWrapping$
 Wrap=�6k    �� AcceptsReturn . ��6   �� *Data+6   �� 5+      $��80��6   $��26��6$   $��Center=�6R     StartButton#���  6m   ��60   �� *StartChecking+6m   5-      �� 5.      $��Right=�6   $ 
Horizontal=�65   $��Center=�6N   .+�50      �� $	��200��6   $��25��6%   $��0,0,0,0q�61     SelectPatternButton#���  6C   ��6t   �� *OpenPatternScinWindow+� 51       52      �� 53      $��* �6(   �� 54      $��* �6(   .+�57      �� $��0��6     MCSearchSticker#���  6P   
�������	 d� 	IsChecked	 6,   �� *IsStickerNeed+6|   �� 58      $��1��6     MCSearchPainSeed#���  6R   
�������	 6,   �� *IsPaintSeedNeed+6   59      5<      5=      � 5?   
   $��2��6   #���  6   .+�5@      �� .��5A      �� $ Vertical=�6   .+�5B      ��   MCFindedScinsWithStickers#���  6   
�������$��20(�6e   $��Center=�6s   �� 5C      $��Stretch=�6   $��Stretch=�6g   $��Stretch=�6�    	 Lststyle#��� 	 6�   #���  6�   $��0,0,0,0q�6  $��Disabled=�6(  ��6=   �� *ScinsWithStickers+5E      �� 5F       $
  MCFindedScinsWithRarityPainrSeed#��� 
 6   
�������$��20(�6l   $��Center=�6z   �� 5G      $��Stretch=�6   $��Stretch=�6o   $��Stretch=�6�     RarityPainSeedList#���  6�   #���  6�   $��0,0,0,0q�6   $��Disabled=�6:  ��6=   �� *ScinsWithRarityPaintSeeds+5I      5J      5L      5N      �� 5P   
   $��3��6   
�������$��1q�63   ._�5Q      �� $ 
Horizontal=�6   #���  62   .+�5R      � $��10,0,0,0q�6   $��12��60   $	��400��6<   $��Center=�6H   
 � Maximum$	
 100Q�6c   
������  � Value 6�   �� *CheckProgress+�� 5S        MCStickerFoundCount#���  6   
�������$��10,0,0,0q�6[   $��10(�6m   $��Center=�6{   $��98��6�   �� 5T      
�������$��10(�6W   $��Center=�6e   $
��Left=�6�   $��50��6�   ��6   �� *ScinsWithStickers.Count+6�   �� 5U        MCPaintSeedFoundCount#���  6   
�������$��10(�6]   $��Center=�6k   $	��140��6�   �� 5V      
�������$��10(�6_   $��Center=�6m   $
��Left=�6�   $	��130��6�   ��6   �� *!ScinsWithRarityPaintSeeds.Count+6�   5W      5X      5Y      5Z      