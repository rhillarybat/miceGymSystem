   M S B A M L   `   `   `  ����H  DMiceGymSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MiceGymSystem.ViewMiceGymSystem.View  5   	   (    "MiceGymSystem.View.CreatePagamento   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MiceGymSystem.View     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignWindow#��[  5   	     MaterialDesignBody#���  5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ CreatePagamento��5   	   $	��720��6!   $
��1280��6.    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q   ��5      �� 5   
    �� ImageSource$ /Resources/Background.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��6* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��10* �6   �� 5      $��5* �6   .+�5    
   � .+�5!      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $��	30,30,0,0q�6J   .+�5"      �� $��37��6   $��82��6)   ��5#      �� 5$      $ /Resources/Alter.png��6%   5&      �� 5'      $��24��6   $��Center=�6)   $ 
Horizontal=�6D   .+�5(      �� $��CADASTRAR CLIENTE��6    $	��646��69   
�������$��34��6X   $
��Bold"�6d   $��18(�6v   $��
19.6,0,0,0q�6�   5)      5+      5-      � 5/   
   $��1��6   .+�50      �� $ 
Horizontal=�6   $��Center=�62   $��	0 25 50 0q�6O   .+�51      �� -   5        	 ��Name$	 
lbNomeUser��51      $��USUÁRIO (NOME)��60   
�������$��SemiBold"�6Y   $��	0 10 10 0q�6o   $	��Top=�6�   $��16(�6�   
 �� TextAlignment$
 Right=�6�   '  !MaterialDesignThemes.Wpf.PackIcon  52         Kind$ AccountCircle=�6*   
�������$��40��6R   $��40��6]   53      54      � 56   
   $��1��6   $��30q�6   $
��Left=�6(   .+�57      �� $��0,0,0,0q�6   .+�58      �� $	��500��6   $��0 0 0 10q�6)   .+�59      �� -   5         ��Name$ 
cbFormaPag��59      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Forma de Pagamento��5:       " MaterialDesignOutlinedComboBox#��[ 5;      
�������
�������$	��500��6b   .@�5=      �� $��Dinheiro��5>      �� 5?      $��Cartão de Crédito��5@      �� 5A      $��Cartão de Débito��5B      �� 5C      $	��Pix��5D      5E      5G      �� 5H      $	��500��6   $��0 0 0 10q�6)   .+�5I      �� -   5         ��Name$ tbValor��5I      $	��Top=�5J      $ Valor��5K       �� AcceptsReturn .  ! MaterialDesignOutlinedTextBox#��[ 5M       �� TextWrapping$
 Wrap=�5N      
�������
�������$��1.5,1.5,1.5,1.5q�6<   5P      �� 5Q      $	��500��6   $��0 0 0 10q�6)   .+�5R      (  "System.Windows.Controls.DatePicker  -   5          Name$ dtData��5R   !   $��2,2,2,2q�5S      $ Data de Pagamento��5T       $  MaterialDesignOutlinedDatePicker#��[ 5U      $	��500��6=   
�������
�������}�.  6p   5W      �� 5X      $	��500��6   $��0 0 0 10q�6)   .+�5Y      �� -   5        $ 	cbCliente��5Y      $ Cliente��5Z      #��[ 5[      
�������
�������$	��500��6b   5]      5^      5_      5`      � 5b   
   $��2��6   $
��Left=�6   $��30,0,0,0q�67   .+�5c      �� .+�5d      �� -   5         ��Name$ btSalvar��5d      $��0 0 0 10q�6+   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5e       # MaterialDesignRaisedLightButton#��[ 5g       � ToolTip$8 2MaterialDesignRaisedLightButton with Round Corners��5h      $	��250��6J   $��50��6V   
�������
������� � Cursor$
 Hand��6�   {�5f      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5i      �� $��SALVAR��6    $
��Bold"�6.   $��18(�6@   5j      �� 5k      -   5        $ 
btCancelar��5k      $��0 0 0 10q�6-   $ 5��5l      #��[ 5n      $8 2MaterialDesignRaisedLightButton with Round Corners��5o      $	��250��6>   $��50��6J   
�������
�������{�5m      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5p      �� $��CANCELAR��6    $
��Bold"�60   $��18(�6B   5q      �� 5r      -   5        $ btVoltar��5r      $��0 0 0 10q�6+   $ 5��5s      #��[ 5u      $8 2MaterialDesignRaisedLightButton with Round Corners��5v      $	��250��6>   $��50��6J   
�������
�������{�5t      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5w      �� $��VOLTAR��6    $
��Bold"�6.   $��18(�6@   5x      5y      5z      5{      5|      