   M S B A M L   `   `   `  ����@  <TUSUR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Kursovaya	Kursovaya  5   	   M ISystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M3clr-namespace:System.ComponentModel;assembly=SystemSystem.ComponentModel 6/       Kursovaya.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Kursovaya     5   	   Bcm3clr-namespace:System.ComponentModel;assembly=System     6/     � Title$&   Работа с матрицей��5   	   $	��650��6#   $
��1000��60    � Icon$ arr.png��6=    � 
ResizeMode$ NoResize=�6L    � 	Resources 5	         Kursovaya.Converter   myConverter  GridCell � DataContext �� RelativeSource �� AncestorType �� 	Converter �� Path	 �� 
TargetType  
btTemplate
 ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value��%�  &	        &	      7   &	 �       5
   
   6   �� 5   
   .R�5      ��  6   ��  �� $ DataGridCellL�8   ��6�   �� $ Value���6�   �� $ Color�5      �� 5   
   "	 ��6   .R�5      �� $
 buttonBorder��6   $ 20��6+   
�����_�$��2q�6U   
����ح�$��40��5   ,   $	��100��68   ._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Матрица��6d   5       5      P� 5       �@J�IsMouseOver . . �5      �� $ buttonBorder��6    � ��
 ��� �6M   5      P� 5       � �� . . �5      �� $ buttonBorder��6    � ��
 ��  �6N   5      5      5      .��5      � $��
0,-23,-8,0q�6    J� RenderTransformOrigin$ 0.687,0.754&�6    � RowDefinitions 5    
   �� 5!      $	��17* �6   �� 5"      $
��626* �6   .+�5$   
   �� -   5         ��Name$ strField��5$      $
��Left=�6$   $��26��6?   $��	10,69,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $��10��6r   $	��Top=�6|   $��61��6�   $��1��6�   �� 5%   
   -   5        $ colField��5%      $
��Left=�6$   $��26��6?   $��	97,69,0,0q�6K   $
 Wrap=�6^   $	��Top=�6r   $��61��6�   $��10��6�   $��1��6�   �� 5&   
   $��строки��6   $
��Left=�6!   $��	10,37,0,0q�6<   $	��Top=�6O   $��25��6g   $��1��6s   �� 5'   
   $��столбцы��6   $
��Left=�6"   $��	97,36,0,0q�6=   $	��Top=�6P   $��61��6h   $ 0.5,0.5&�6s   $��1��6�   &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ matrix2��5(      $
��Left=�6R   $	��586��6m   $��
246,11,0,0q�6z   $	��Top=�6�   $	��690��6�   $��1��6�   6�   �� 5)   
   -   5         ��Name$ createMatrixButton��5)      $��Матрица��6-   #��[ 6?   $��10,122,867,0q�6f   $	��Top=�6|   $��52��6�   $��1��6�   5*      5,      