   M S B A M L   `   `   `  ����]  YEjercicio1_Recuperacion_Lucas_Sanz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Ejercicio1_Recuperacion_Lucas_Sanz"Ejercicio1_Recuperacion_Lucas_Sanz  5   	   3    -Ejercicio1_Recuperacion_Lucas_Sanz.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:Ejercicio1_Recuperacion_Lucas_Sanz     5   	     � Title$  CALCULADORA SEGUROS��5   	   $	��450��6%   $	��800��62    � 
ResizeMode$ NoResize=�6>   .��5	      � .+�5
   
   �� $��Nombre��6   $
��Left=�6!   $��	28,24,0,0q�6<   $	��Top=�6O   �� 5   
   -   5        $��
txt_nombre��5      $
��Left=�6$   $��	87,28,0,0q�6?    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   �� 5   
   $��Seguro a seleccionar��6   $	��NaN��61   $��55,77,493,217q�6>   $	��NaN��6U   .��5      � $	��NaN��6   $��	77,0,18,0q�6    $	��NaN��63   .+�5      	� -   5        $��
rdb_basico��5       	� 	GroupName$ 
tiposeguro��60   $��Básico��6G   $
��Left=�6X   $��	46,22,0,0q�6s   $	��Top=�6�   	� 5      -   5        $��rdb_terceros��5      $ 
tiposeguro��62   $��
A terceros��6I   $
��Left=�6^   $��	46,47,0,0q�6y   $	��Top=�6�   	� 5      -   5        $��	rdb_total��5      $ 
tiposeguro��6/   $��Total��6F   $
��Left=�6V   $��	46,73,0,0q�6q   $	��Top=�6�   5      5      �� 5   
   $��Seguro��6   $
��Left=�6!   $��
71,106,0,0q�6<   $	��Top=�6P   �� 5   
   $��Equipamiento��6   $	��NaN��6)   $��361,77,188,217q�66   $	��NaN��6N   .��5      �  � ColumnDefinitions 5      �� 5      $	��38* �6'   �� 5      $
��201* �6'   .+�5      �� $��Equipo��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $��2��6o   �� 5      -   5        $��chk_aire��5      $��Aire acondicionado��6+   $
��Left=�6H   $��	20,34,0,0q�6c   $	��Top=�6v   $��1��6�   �� 5      -   5        $��	chk_audio��5      $��Sistema audio��6,   $
��Left=�6D   $��	20,59,0,0q�6_   $	��Top=�6r   $��1��6�   5      5      �� 5    
   $��Costo��6   $
��Left=�6    $��
55,235,0,0q�6;   $	��Top=�6O   �� 5!   
   -   5        $��	txt_costo��5!      $
��Left=�6#   $��104,239,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��104��6�   �� 5"   
   -   5        $��btn_cotizar��5"      $��Cotizar��6$   $
��Left=�66   $��296,237,0,0q�6Q   $	��Top=�6f   $��83��6~   6�   �� 5#   
   -	   5        $��
txt_salida��5#      $
��Left=�6$   $��
55,280,0,0q�6?   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��557��6�   $	��119��6�   5'      5(      