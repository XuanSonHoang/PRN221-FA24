   M S B A M L   `   `   `  ����Q  MPRN221_SE1747_FirstWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PRN221_SE1747_FirstWPFPRN221_SE1747_FirstWPF  5   	   *    $PRN221_SE1747_FirstWPF.UpdateStudent   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PRN221_SE1747_FirstWPF     5   	     � Title$  UpdateStudent��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �� $��1��6   .+�5   
   �� $��20(�6   $
��Bold"�6   $��Center=�60   .��6M   Update Student6]   �� 5   
   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��1 1 1 1q�62   .+�5      �� $��90��6   .��6#   ID6'   �� 5      -   5        $��txtID��5   8   $	��600��6   ${�False��6&   $��25��6m   ��6E   ��  �� Path$ Id� �� Mode$ OneWay=�6m   5      �� 5      $ 
Horizontal=�6   $��1 10 1 1q�62   .+�5      �� $��90��6   .��6#   Name6)   �� 5      -   5        $��txtName��5   7   $	��600��6   $
{�True��6&   $��25��6p   ��6F   �� $
 Name�$ OneWay=�6p   5      �� 5      $ 
Horizontal=�6   $��1 10 1 1q�62   .+�5      �� $��90��6   .��6#   Gender6+   	� 5      -   5        $��rbMale��5      $
��Male��6,   6=   	� 5      -   5        $��rbFemale��5      $��Female��6.   $��10 1 1 1q�6?   6S   5      �� 5      $ 
Horizontal=�6   $��1 10 1 1q�62   .+�5      �� $��90��6   .��6#   
Birthday6-   (  "System.Windows.Controls.DatePicker  5       -   5        $��
dpBirthday��5       $	��600��6/   $
{�True��6;   $��25��6�      SelectedDate 6L   �� $ Birthday�$ OneWay=�6�   5!      �� 5#      $ 
Horizontal=�6   $��1 10 1 1q�62   .+�5$      �� $��90��6   .��6#   GPA6(   �� 5%      -   5        $��txtGpa��5%   7   $	��600��6   $
{�True��6&   $��25��6n   ��6E   �� $	 Gpa�$ OneWay=�6n   5&      �� 5(      $ 
Horizontal=�6   $��1 10 1 1q�62   .+�5)      �� $��90��6   .��6#   
Department6/   �� 5*      -   5        $��cbDepartment��5*   8   $	��600��6   $
{�True��6'   $��25��6}    �� Text 6L   �� $ Depart.Name�$ OneWay=�6�   5+      5,      �� 5.   
   $��5 5 5 10q�6   .+�5/      �� $ 
Horizontal=�6   $��1 10 1 1q�62   $��Center=�6D   .+�50      �� -   5        $��	btnUpdate��50      $��Update��6*   $	��100��6;   $��30��6G   $��1 1 10 1q�6k   6   �� 51      -	   5        $��btnClear��51      $��Clear��6)   $	��100��69   $��30��6E   $��1 1 10 1q�6h   6|   52      53      54      55      