   M S B A M L   `   `   `  ����J  FTestTaskNovosib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TestTaskNovosibTestTaskNovosib  5   	        TestTaskNovosib.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TestTaskNovosib     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5        .+�5
   
   �� -   5         ��Name$ comboBoxSelectCity��5
      $
��Left=�6/   $��	49,64,0,0q�6J   $	��Top=�6]   $	��176��6u   6�   �� 5   
   -   5         ��Name$ 
buttonSave��5      $��Сохранить��6%   $
��Left=�69   $��575,162,0,0q�6T   $	��Top=�6i   $��43��6�   $	��104��6�    J� RenderTransformOrigin$ 2.596,-2.79&�6�   �� 5   
   -   5        $ comboBoxSelectFactory��5      $
��Left=�62   $��
271,64,0,0q�6M   $	��Top=�6a   $	��190��6y   6�   �� 5   
   -   5        $ comboBoxSelectEmployee��5      $
��Left=�63   $��
511,64,0,0q�6N   $	��Top=�6b   $	��258��6z   6�   �� 5   
   -   5        $ buttonReset��5      $��Сбросить��6&   $
��Left=�69   $��
49,237,0,0q�6T   $	��Top=�6h   $��26��6�   $��92��6�   $ 0.478,1.002&�6�   	� 5   
   -   5         	�Name$ Brigade1��5      $��1 смена (8:00-20:00)��6(   $
��Left=�6G   $��
49,150,0,0q�6b   $	��Top=�6v    d� 	IsChecked$ FalseY�6�   6�   	� 5   
   -   5        $ Brigade2��5      $��2 смена (20:00-8:00)��6(   $
��Left=�6G   $��
49,178,0,0q�6b   $	��Top=�6v   6�   �� 5   
   -	   5         ��Name$ WorkingShift��5      $
��Left=�6'   $��271,178,0,0q�6B   $	��Top=�6W   $	��190��6o    � SmallChange$ 1Q�6{    � Maximum$ 12Q�6�   	 � Value$	 -1Q�6�   
 �� TickPlacement$
 BottomRight=�6�    �� IsSnapToTickEnabled . 6�   �� 5   
   -
   5         ��Name$ WorkingShiftLabel��5      $��0��6+   $
��Left=�67   $��358,144,0,0q�6R   $	��Top=�6g   $ -0.29,-0.191&�6   �� 5   
   -   5        $ Errors��5      $�� ��6    $
��Left=�6+   $��530,219,0,0q�6F   $	��Top=�6[   $ 
-2.7,0.541&�6s   $	��220��6�   $	��121��6�   5      5      