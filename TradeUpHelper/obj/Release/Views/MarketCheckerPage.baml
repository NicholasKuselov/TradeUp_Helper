   M S B A M L   `   `   `  ���� H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  K*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  +    %TradeUpHelper.Views.MarketCheckerPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:TradeUpHelper.Views     =
viewmodels&clr-namespace:TradeUpHelper.ViewModels     A
converters*clr-namespace:TradeUpHelper.DataConverters     -     N� Title$  MarketCheckerPage�� � 	Resources 5   /TradeUpHelper.DataConverters.ShortWearConverter   shortWearConverter �� MergedDictionaries �� Source��  �� $1 +/Resources/Styles/WindowControlButtons.xaml?��� $, &/Resources/Styles/TextBoxesStyles.xaml?��� $) #/Resources/Styles/LabelsStyles.xaml?��� $* $/Resources/Styles/ButtonsStyles.xaml?��� $+ %/Resources/Styles/MainMenuStyles.xaml?��� $4 ./Resources/Styles/MarketCheckerListStyles.xaml?�%   &	           � DataContext 2  ,TradeUpHelper.ViewModels.MarketCheckerPageVM  .���  � RowDefinitions �� $��14 ��� $��40 ��� $��* ��� $��30 �.+���   Color_WindowBackground#���  $��0��$��10(�$��Stretch=�$��Center=�$��0,0,0,0q�$��0,0,0,0q�  MCSIHWarning#���  
�������� $��1��#���  .+��� $
��Left=� �� Orientation$ 
Horizontal=�.+��� $	��300��$��26��  SIH_Page#���   �� TextWrapping$
 Wrap=� �� AcceptsReturn . ���� *Data+�� $��80��$��26��$��Center=�  StartButton#���  ���� *StartChecking+�� $��Right=�$ 
Horizontal=�$��Center=�.+��� $	��200��$��25��$��0,0,0,0q�  SelectPatternButton#���  ���� *OpenPatternScinWindow+�  �� $��* ��� $��* �.+��� $��0��  MCSearchSticker#���  
�������	 d� 	IsChecked	 �� *IsStickerNeed+�� $��1��  MCSearchPainSeed#���  
�������	 �� *IsPaintSeedNeed+� $��2��#���  .+��� .���� $ Vertical=�.+���   MCFindedScinsWithStickers#���  
�������$��20(�$��Center=��� $��Stretch=�$��Stretch=�$��Stretch=� 	 Lststyle#��� 	 #���  $��0,0,0,0q�$��Disabled=����� *ScinsWithStickers+��  $
  MCFindedScinsWithRarityPainrSeed#��� 
 
�������$��20(�$��Center=��� $��Stretch=�$��Stretch=�$��Stretch=�  RarityPainSeedList#���  #���  $��0,0,0,0q�$��Disabled=����� *ScinsWithRarityPaintSeeds+�� $��3��
�������$��1q�._��� $ 
Horizontal=�#���  .+�� $��10,0,0,0q�$��12��$	��400��$��Center=�
 � Maximum$	
 100Q�
������  � Value �� *CheckProgress+��   MCStickerFoundCount#���  
�������$��10,0,0,0q�$��10(�$��Center=�$��98���� 
�������$��10(�$��Center=�$
��Left=�$��50������ *ScinsWithStickers.Count+��   MCPaintSeedFoundCount#���  
�������$��10(�$��Center=�$	��140���� 
�������$��10(�$��Center=�$
��Left=�$	��130������ *ScinsWithStickers.Count+