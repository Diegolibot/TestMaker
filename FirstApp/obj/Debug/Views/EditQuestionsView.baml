   M S B A M L   `   `   `  ����D  @TestMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FirstApp.ViewsFirstApp.Views  5      &     FirstApp.Views.EditQuestionsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:FirstApp.Views     5      
�������.��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid     AlternatingRowBackground
 �����   CanUserAddRows .     AutoGenerateColumns .  ��6   ��  �� Path$ 	Questions� �� Mode$ OneWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Question Text��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� $ QuestionText�6d     5      $ Id��6%    61   �� $	 IdQ�6P   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Image��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 SizeToCells 68   
   
IsReadOnly
 .    CellTemplate 5      �� 5      .R�5      �� ��6$   �� *Image+5      5        5       $
 Edit��6)   $	 SizeToCells 67   
 .  5"      �� 5#      .R�5$      �� $
��Edit��6%   5%      5'      5*      5,      5-      