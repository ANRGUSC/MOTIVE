   M S B A M L   `   `   `  ����   WpfApplication1    WpfApplication1.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  win1_main_window�� � Title$ MOTIVE - Local Vehicle��$	��640�� � 
ResizeMode$ NoResize=� � SizeToContent$ WidthAndHeight=�.��� -    �Name$ win1_main_grid�����	#FFE4E4E4.+�� -   $ win1_status_grid��$��Center=�$	��120��$��10,320,10,10q�$��Bottom=�$	��614��.+��� -    ��Name$ win1_status_groupbox��$��	My Status��$��Center=�$	��100��$��
10,0,10,10q�$��Bottom=�$	��594��.��� -   $ win1_status_groupbox_grid��$
��Left=�$��84��$��0,0,-3.2,-5.6q�$	��Top=�$	��584��.+��� -    ��Name$* $win1_status_groupbox_grid_separator1��$
��Left=�$��84��$��	146,0,0,0q�$	��Top=�$��5���� -   $* $win1_status_groupbox_grid_separator2��$
��Left=�$��84��$��	292,0,0,0q�$	��Top=�$��5���� -   $* $win1_status_groupbox_grid_separator3��$
��Left=�$��84��$��	438,0,0,0q�$	��Top=�$��5���� -	    ��Name$* $win1_status_groupbox_vehicleid_label��$��Vehicle ID:��$
��Left=�$	��Top=�$	��141���� -
   $' !win1_status_groupbox_rating_label��$��Rating:��$
��Left=�$��26��$��	156,0,0,0q�$	��Top=�$	��135���� -   $( "win1_status_groupbox_balance_label��$��Balance:��$
��Left=�$��26��$��	302,0,0,0q�$	��Top=�$	��136���� -   $( "win1_status_groupbox_counter_label��$��Counter:��$
��Left=�$��26��$��	448,0,0,0q�$	��Top=�$	��130���� -    ��Name$. (win1_status_groupbox_vehicleid_textblock��$
��Left=�$��48��$��	10,26,0,0q�$
��Wrap=�$	��Top=�$	��131��$��20(�	 �� TextAlignment$	 Center=��� 
 � Language$
 en-sg�$�?���� -   $+ %win1_status_groupbox_rating_textblock��$
��Left=�$��48��$��
156,26,0,0q�$
��Wrap=�$	��Top=�$	��131��$��20(�$	 Center=���Z� �� $
 en-sg�$	�0.0���� -   $2 ,win1_status_groupbox_balance_value_textblock��$
��Left=�$��29��$��
302,26,0,0q�$
��Wrap=�$	��Top=�$	��131��$��20(�$	 Center=��� $
 en-sg�$�0���� -   $. (win1_status_groupbox_balance_units_label��$	��ETH��$
��Left=�$��19��$��
302,55,0,0q�$	��Top=�$	��131��$��0q�$��Center=�$��Center=��� -   $2 ,win1_status_groupbox_counter_value_textblock��$
��Left=�$��29��$��
448,26,0,0q�$
��Wrap=�$��0��$	��Top=�$	��130��$��20(�$	 Center=��� -   $. (win1_status_groupbox_counter_units_label��$��	Second(s)��$
��Left=�$��
448,55,0,0q�$	��Top=�$��19��$	��130��$��0q�$��Center=�$��Center=�� -   $ win1_messagebox_grid��$
��Left=�$	��305��$��
10,0,0,130q�$��Bottom=�$	��614��.+��� -    ��Name$% win1_messagebox_history_textbox��$
��Left=�$��
10,10,0,86q� �� TextWrapping$
 Wrap=�$��History��$	��594��" �� VerticalScrollBarVisibility$
 Auto=� �� 
IsReadOnly .  �� IsUndoEnabled .  $��14(��� -    ��Name$$ win1_messagebox_current_border��
���   �$��1q�$
��Left=�$��47��$��	10,0,0,30q�$��Bottom=�$	��594��$��Disabled=�._��� -   $' !win1_messagebox_current_textblock��$
��Left=�$��-0.8,-0.8,-0.2,0q�$
��Wrap=�$��Current��$��Center=�$	��593�� �� Padding$	 5,0q�$��Disabled=�$��16(�� -    �Name$! win1_messagebox_progressbar��$
��Left=�$��15��$��
10,280,0,0q�$	��Top=�$	��594��$y�Hidden=�� -   $ win1_current_grid��$
��Left=�$��50��$��10,0,0,435.4q�$��Bottom=�$	��614��.+��� -   $ win1_current_border��
�������$��1q�$
��Left=�$��29��$��	10,11,0,0q�$	��Top=�$	��594��._��� -   $ win1_current_textblock��$��Center=�$��29��$��-0.8,-0.8,-0.2,-1q�$
��Wrap=�$��Current Job��$	��Top=�$	��593��$��20(�$	 5,0q�� -   $ win1_status_other_grid��$��Center=�$	��120��$��10,10,9.6,480.4q�$	��614��.+��� -   $  win1_status_other_groupbox��$��Peer's Status��$��Center=�$	��100��$��
10,0,10,10q�$��Bottom=�$	��594��.��� -   $% win1_status_other_groupbox_grid��$
��Left=�$��84��$��0,0,-3.2,-5.6q�$	��Top=�$	��584��.+��� -   $0 *win1_status_other_groupbox_grid_separator1��$
��Left=�$��84��$��	194,0,0,0q�$	��Top=�$��5���� -   $0 *win1_status_other_groupbox_grid_separator2��$
��Left=�$��84��$��	389,0,0,0q�$	��Top=�$��5���� -    $0 *win1_status_other_groupbox_vehicleid_label��$��Vehicle ID:��$
��Left=�$	��Top=�$	��189���� -!   $- 'win1_status_other_groupbox_rating_label��$��Rating:��$
��Left=�$��26��$��	204,0,0,0q�$	��Top=�$	��180���� -"   $. (win1_status_other_groupbox_balance_label��$��Balance:��$
��Left=�$��26��$��	399,0,0,0q�$	��Top=�$	��175���� -#   $4 .win1_status_other_groupbox_vehicleid_textblock��$
��Left=�$��48��$��0,26,0,0q�$
��Wrap=�$	��Top=�$	��189��$��20(�$	 Center=��� $
 en-sg�$�?���� -$   $1 +win1_status_other_groupbox_rating_textblock��$
��Left=�$��48��$��
204,26,0,0q�$
��Wrap=�$	��Top=�$	��180��$��20(�$	 Center=���Z� �� $
 en-sg�$	�0.0���� -%   $8 2win1_status_other_groupbox_balance_value_textblock��$
��Left=�$��29��$��
399,26,0,0q�$
��Wrap=�$	��Top=�$	��175��$��20(�$	 Center=��� $
 en-sg�$�0���� -&   $4 .win1_status_other_groupbox_balance_units_label��$	��ETH��$
��Left=�$��19��$��
399,55,0,0q�$	��Top=�$	��175��$��0q�$��Center=�$��Center=�