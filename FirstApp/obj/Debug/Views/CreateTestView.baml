   M S B A M L   `   `   `  ����D  @TestMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FirstApp.ViewsFirstApp.Views  5      #    FirstApp.Views.CreateTestView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:FirstApp.Views     5      
�������$��Microsoft YaHei)�5   K   .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $	��100��6   $��* �6,   �� 5      $
��auto �6   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5!   
   �� $��1��6   $��2��6!   $��2��61   $��60(�6E   $��Create Your Test��6S   �� 5$   
   $��3��6   $��2��6!   $��Topic or Subject��61   �� 5%   
   -   5         ��Name$ Topics��5%   0   $��3��6   $��3��6     �� DisplayMemberPath$
 Name��5'   	    �� SelectedItem 5&   	   ��  �� Path$ SelectedTopic� �� Mode$ OneWayToSource=�5'   	   �� 5*   
   $��5��6   $��2��6!   $��Time (Minutes)��61   �� 5+   
   $��5��6   $��3��6     5,      �� $ SelectedTime�$ OneWayToSource=�.@�5-      �� $��40��6   �� 5.      $��50��6   �� 5/      $��60��6   �� 50      $��70��6   �� 51      $��80��6   �� 52      $��90��6   �� 53      $	��100��6   �� 54      $	��110��6   �� 55      $	��120��6   56      �� 59   
   $��7��6   $��2��6!   $��Number of Questions��61   �� 5:   
   -   5        $ NumberOfQuestions��5:   0   $��7��6   $��3��6     5;      �� $ SelectedNumberOfQuestions�$ OneWayToSource=��� 5=   
   -   5         ��Name$ 	StartTest��5=      $��9��6$   $��2��61   $��2��6A   $	��100��6U   $��
Start Test��6a   �� 5?   
   -   5         ��Name$ MaxQUestions��5?   1   $��9��6   $��3��6!   61   5@      5B      