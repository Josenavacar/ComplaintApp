namespace Advanced_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStart = new System.Windows.Forms.TabPage();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbStudentList = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbStudentName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.lblTimeTask = new System.Windows.Forms.Label();
            this.btnRemoveCleaning = new System.Windows.Forms.Button();
            this.btnAddCleaning = new System.Windows.Forms.Button();
            this.tbCleaning = new System.Windows.Forms.TextBox();
            this.lblTasking = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTasks = new System.Windows.Forms.ListBox();
            this.lblCleaning = new System.Windows.Forms.Label();
            this.tabClean = new System.Windows.Forms.TabPage();
            this.lblTimeCleaning = new System.Windows.Forms.Label();
            this.btnCleaner = new System.Windows.Forms.Button();
            this.lblCleaner = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabGarbage = new System.Windows.Forms.TabPage();
            this.lblTimeGarbage = new System.Windows.Forms.Label();
            this.btnGarbage = new System.Windows.Forms.Button();
            this.lblGarbage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.tbGrocer = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDelItem = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.clbStudents = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbItemPrice = new System.Windows.Forms.TextBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.tabComplaint = new System.Windows.Forms.TabPage();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbComplaint = new System.Windows.Forms.TextBox();
            this.cbStudents = new System.Windows.Forms.ComboBox();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.lbHiddenDisplayItems = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDisplayItems = new System.Windows.Forms.ListBox();
            this.lbDisplay = new System.Windows.Forms.ListBox();
            this.cbDisplay = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabStart.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.tabClean.SuspendLayout();
            this.tabGarbage.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabComplaint.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStart);
            this.tabControl1.Controls.Add(this.tabTasks);
            this.tabControl1.Controls.Add(this.tabClean);
            this.tabControl1.Controls.Add(this.tabGarbage);
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Controls.Add(this.tabComplaint);
            this.tabControl1.Controls.Add(this.tabDisplay);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(650, 399);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStart
            // 
            this.tabStart.Controls.Add(this.btnStart);
            this.tabStart.Controls.Add(this.btnRemove);
            this.tabStart.Controls.Add(this.label6);
            this.tabStart.Controls.Add(this.lbStudentList);
            this.tabStart.Controls.Add(this.btnAdd);
            this.tabStart.Controls.Add(this.tbStudentName);
            this.tabStart.Controls.Add(this.label5);
            this.tabStart.Location = new System.Drawing.Point(4, 22);
            this.tabStart.Margin = new System.Windows.Forms.Padding(2);
            this.tabStart.Name = "tabStart";
            this.tabStart.Size = new System.Drawing.Size(642, 373);
            this.tabStart.TabIndex = 4;
            this.tabStart.Text = "Start";
            this.tabStart.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(446, 200);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 105);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start Application!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(265, 112);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(123, 49);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Student";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(206, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 26);
            this.label6.TabIndex = 4;
            this.label6.Text = "Student List";
            // 
            // lbStudentList
            // 
            this.lbStudentList.FormattingEnabled = true;
            this.lbStudentList.Location = new System.Drawing.Point(148, 200);
            this.lbStudentList.Margin = new System.Windows.Forms.Padding(2);
            this.lbStudentList.Name = "lbStudentList";
            this.lbStudentList.Size = new System.Drawing.Size(240, 108);
            this.lbStudentList.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(148, 112);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 49);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // tbStudentName
            // 
            this.tbStudentName.Location = new System.Drawing.Point(148, 82);
            this.tbStudentName.Margin = new System.Windows.Forms.Padding(2);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.Size = new System.Drawing.Size(240, 20);
            this.tbStudentName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(142, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 36);
            this.label5.TabIndex = 0;
            this.label5.Text = "Add The Students";
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.button1);
            this.tabTasks.Controls.Add(this.lblTimeTask);
            this.tabTasks.Controls.Add(this.btnRemoveCleaning);
            this.tabTasks.Controls.Add(this.btnAddCleaning);
            this.tabTasks.Controls.Add(this.tbCleaning);
            this.tabTasks.Controls.Add(this.lblTasking);
            this.tabTasks.Controls.Add(this.label9);
            this.tabTasks.Controls.Add(this.lbTasks);
            this.tabTasks.Controls.Add(this.lblCleaning);
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Size = new System.Drawing.Size(642, 373);
            this.tabTasks.TabIndex = 6;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // lblTimeTask
            // 
            this.lblTimeTask.AutoSize = true;
            this.lblTimeTask.Location = new System.Drawing.Point(614, 0);
            this.lblTimeTask.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeTask.Name = "lblTimeTask";
            this.lblTimeTask.Size = new System.Drawing.Size(0, 13);
            this.lblTimeTask.TabIndex = 12;
            // 
            // btnRemoveCleaning
            // 
            this.btnRemoveCleaning.Location = new System.Drawing.Point(154, 336);
            this.btnRemoveCleaning.Name = "btnRemoveCleaning";
            this.btnRemoveCleaning.Size = new System.Drawing.Size(134, 23);
            this.btnRemoveCleaning.TabIndex = 11;
            this.btnRemoveCleaning.Text = "Remove Cleaning Task";
            this.btnRemoveCleaning.UseVisualStyleBackColor = true;
            this.btnRemoveCleaning.Click += new System.EventHandler(this.btnRemoveCleaning_Click);
            // 
            // btnAddCleaning
            // 
            this.btnAddCleaning.Location = new System.Drawing.Point(17, 336);
            this.btnAddCleaning.Name = "btnAddCleaning";
            this.btnAddCleaning.Size = new System.Drawing.Size(131, 23);
            this.btnAddCleaning.TabIndex = 10;
            this.btnAddCleaning.Text = "Add Cleaning Task";
            this.btnAddCleaning.UseVisualStyleBackColor = true;
            this.btnAddCleaning.Click += new System.EventHandler(this.btnAddCleaning_Click);
            // 
            // tbCleaning
            // 
            this.tbCleaning.Location = new System.Drawing.Point(16, 301);
            this.tbCleaning.Name = "tbCleaning";
            this.tbCleaning.Size = new System.Drawing.Size(272, 20);
            this.tbCleaning.TabIndex = 8;
            // 
            // lblTasking
            // 
            this.lblTasking.AutoSize = true;
            this.lblTasking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasking.Location = new System.Drawing.Point(447, 60);
            this.lblTasking.Name = "lblTasking";
            this.lblTasking.Size = new System.Drawing.Size(53, 20);
            this.lblTasking.TabIndex = 5;
            this.lblTasking.Text = "name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(344, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Task being performed by:";
            // 
            // lbTasks
            // 
            this.lbTasks.FormattingEnabled = true;
            this.lbTasks.Items.AddRange(new object[] {
            "Clean Kitchen",
            "Clean Bathroom",
            "Clean Toilets",
            "Trash Disposal"});
            this.lbTasks.Location = new System.Drawing.Point(16, 36);
            this.lbTasks.Name = "lbTasks";
            this.lbTasks.Size = new System.Drawing.Size(272, 251);
            this.lbTasks.TabIndex = 2;
            this.lbTasks.SelectedIndexChanged += new System.EventHandler(this.lbTasks_SelectedIndexChanged);
            // 
            // lblCleaning
            // 
            this.lblCleaning.AutoSize = true;
            this.lblCleaning.Location = new System.Drawing.Point(13, 11);
            this.lblCleaning.Name = "lblCleaning";
            this.lblCleaning.Size = new System.Drawing.Size(39, 13);
            this.lblCleaning.TabIndex = 0;
            this.lblCleaning.Text = "Tasks:";
            // 
            // tabClean
            // 
            this.tabClean.Controls.Add(this.lblTimeCleaning);
            this.tabClean.Controls.Add(this.btnCleaner);
            this.tabClean.Controls.Add(this.lblCleaner);
            this.tabClean.Controls.Add(this.label1);
            this.tabClean.Location = new System.Drawing.Point(4, 22);
            this.tabClean.Margin = new System.Windows.Forms.Padding(2);
            this.tabClean.Name = "tabClean";
            this.tabClean.Padding = new System.Windows.Forms.Padding(2);
            this.tabClean.Size = new System.Drawing.Size(642, 373);
            this.tabClean.TabIndex = 0;
            this.tabClean.Text = "Cleaning";
            this.tabClean.UseVisualStyleBackColor = true;
            // 
            // lblTimeCleaning
            // 
            this.lblTimeCleaning.AutoSize = true;
            this.lblTimeCleaning.Location = new System.Drawing.Point(532, 2);
            this.lblTimeCleaning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeCleaning.Name = "lblTimeCleaning";
            this.lblTimeCleaning.Size = new System.Drawing.Size(26, 13);
            this.lblTimeCleaning.TabIndex = 3;
            this.lblTimeCleaning.Text = "time";
            // 
            // btnCleaner
            // 
            this.btnCleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleaner.Location = new System.Drawing.Point(200, 118);
            this.btnCleaner.Margin = new System.Windows.Forms.Padding(2);
            this.btnCleaner.Name = "btnCleaner";
            this.btnCleaner.Size = new System.Drawing.Size(158, 86);
            this.btnCleaner.TabIndex = 2;
            this.btnCleaner.Text = "Didn\'t Clean";
            this.btnCleaner.UseVisualStyleBackColor = true;
            this.btnCleaner.Click += new System.EventHandler(this.BtnCleaner_Click);
            // 
            // lblCleaner
            // 
            this.lblCleaner.AutoSize = true;
            this.lblCleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleaner.Location = new System.Drawing.Point(347, 35);
            this.lblCleaner.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCleaner.Name = "lblCleaner";
            this.lblCleaner.Size = new System.Drawing.Size(92, 31);
            this.lblCleaner.TabIndex = 1;
            this.lblCleaner.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person Cleaning:";
            // 
            // tabGarbage
            // 
            this.tabGarbage.Controls.Add(this.lblTimeGarbage);
            this.tabGarbage.Controls.Add(this.btnGarbage);
            this.tabGarbage.Controls.Add(this.lblGarbage);
            this.tabGarbage.Controls.Add(this.label2);
            this.tabGarbage.Location = new System.Drawing.Point(4, 22);
            this.tabGarbage.Margin = new System.Windows.Forms.Padding(2);
            this.tabGarbage.Name = "tabGarbage";
            this.tabGarbage.Padding = new System.Windows.Forms.Padding(2);
            this.tabGarbage.Size = new System.Drawing.Size(642, 373);
            this.tabGarbage.TabIndex = 1;
            this.tabGarbage.Text = "Garbage";
            this.tabGarbage.UseVisualStyleBackColor = true;
            // 
            // lblTimeGarbage
            // 
            this.lblTimeGarbage.AutoSize = true;
            this.lblTimeGarbage.Location = new System.Drawing.Point(543, 0);
            this.lblTimeGarbage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeGarbage.Name = "lblTimeGarbage";
            this.lblTimeGarbage.Size = new System.Drawing.Size(26, 13);
            this.lblTimeGarbage.TabIndex = 4;
            this.lblTimeGarbage.Text = "time";
            // 
            // btnGarbage
            // 
            this.btnGarbage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGarbage.Location = new System.Drawing.Point(170, 150);
            this.btnGarbage.Margin = new System.Windows.Forms.Padding(2);
            this.btnGarbage.Name = "btnGarbage";
            this.btnGarbage.Size = new System.Drawing.Size(195, 76);
            this.btnGarbage.TabIndex = 3;
            this.btnGarbage.Text = "Didn\'t Throw Garbage";
            this.btnGarbage.UseVisualStyleBackColor = true;
            this.btnGarbage.Click += new System.EventHandler(this.BtnGarbage_Click);
            // 
            // lblGarbage
            // 
            this.lblGarbage.AutoSize = true;
            this.lblGarbage.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGarbage.Location = new System.Drawing.Point(236, 88);
            this.lblGarbage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGarbage.Name = "lblGarbage";
            this.lblGarbage.Size = new System.Drawing.Size(92, 31);
            this.lblGarbage.TabIndex = 2;
            this.lblGarbage.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Person Taking Out The Garbage: ";
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.tbGrocer);
            this.tabItems.Controls.Add(this.btnAddItem);
            this.tabItems.Controls.Add(this.btnDelItem);
            this.tabItems.Controls.Add(this.btnItems);
            this.tabItems.Controls.Add(this.label4);
            this.tabItems.Controls.Add(this.clbStudents);
            this.tabItems.Controls.Add(this.label3);
            this.tabItems.Controls.Add(this.tbItemPrice);
            this.tabItems.Controls.Add(this.lbItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Margin = new System.Windows.Forms.Padding(2);
            this.tabItems.Name = "tabItems";
            this.tabItems.Size = new System.Drawing.Size(642, 373);
            this.tabItems.TabIndex = 2;
            this.tabItems.Text = "Shared Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // tbGrocer
            // 
            this.tbGrocer.Location = new System.Drawing.Point(9, 191);
            this.tbGrocer.Margin = new System.Windows.Forms.Padding(2);
            this.tbGrocer.Name = "tbGrocer";
            this.tbGrocer.Size = new System.Drawing.Size(190, 20);
            this.tbGrocer.TabIndex = 8;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(9, 218);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(90, 85);
            this.btnAddItem.TabIndex = 7;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDelItem
            // 
            this.btnDelItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelItem.Location = new System.Drawing.Point(103, 217);
            this.btnDelItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Size = new System.Drawing.Size(96, 85);
            this.btnDelItem.TabIndex = 6;
            this.btnDelItem.Text = "Remove";
            this.btnDelItem.UseVisualStyleBackColor = true;
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // btnItems
            // 
            this.btnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.Location = new System.Drawing.Point(385, 218);
            this.btnItems.Margin = new System.Windows.Forms.Padding(2);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(173, 85);
            this.btnItems.TabIndex = 5;
            this.btnItems.Text = "Confirm";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.BtnItems_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(202, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 103);
            this.label4.TabIndex = 4;
            this.label4.Text = "Student\'s Who Didn\'t Pay";
            // 
            // clbStudents
            // 
            this.clbStudents.FormattingEnabled = true;
            this.clbStudents.Location = new System.Drawing.Point(423, 118);
            this.clbStudents.Margin = new System.Windows.Forms.Padding(2);
            this.clbStudents.Name = "clbStudents";
            this.clbStudents.Size = new System.Drawing.Size(135, 64);
            this.clbStudents.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(202, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price Of Item:";
            // 
            // tbItemPrice
            // 
            this.tbItemPrice.Location = new System.Drawing.Point(423, 49);
            this.tbItemPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tbItemPrice.Name = "tbItemPrice";
            this.tbItemPrice.Size = new System.Drawing.Size(135, 20);
            this.tbItemPrice.TabIndex = 1;
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Items.AddRange(new object[] {
            "Dish Soap",
            "Sponge",
            "Detergant",
            "Toilet Paper"});
            this.lbItems.Location = new System.Drawing.Point(9, 14);
            this.lbItems.Margin = new System.Windows.Forms.Padding(2);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(190, 173);
            this.lbItems.TabIndex = 0;
            // 
            // tabComplaint
            // 
            this.tabComplaint.Controls.Add(this.btnSubmit);
            this.tabComplaint.Controls.Add(this.tbComplaint);
            this.tabComplaint.Controls.Add(this.cbStudents);
            this.tabComplaint.Location = new System.Drawing.Point(4, 22);
            this.tabComplaint.Margin = new System.Windows.Forms.Padding(2);
            this.tabComplaint.Name = "tabComplaint";
            this.tabComplaint.Size = new System.Drawing.Size(642, 373);
            this.tabComplaint.TabIndex = 3;
            this.tabComplaint.Text = "Custom Complaints";
            this.tabComplaint.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(223, 236);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(118, 67);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit Complaint";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // tbComplaint
            // 
            this.tbComplaint.Location = new System.Drawing.Point(118, 44);
            this.tbComplaint.Margin = new System.Windows.Forms.Padding(2);
            this.tbComplaint.Multiline = true;
            this.tbComplaint.Name = "tbComplaint";
            this.tbComplaint.Size = new System.Drawing.Size(322, 188);
            this.tbComplaint.TabIndex = 1;
            // 
            // cbStudents
            // 
            this.cbStudents.FormattingEnabled = true;
            this.cbStudents.Location = new System.Drawing.Point(182, 20);
            this.cbStudents.Margin = new System.Windows.Forms.Padding(2);
            this.cbStudents.Name = "cbStudents";
            this.cbStudents.Size = new System.Drawing.Size(200, 21);
            this.cbStudents.TabIndex = 0;
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.lbHiddenDisplayItems);
            this.tabDisplay.Controls.Add(this.label7);
            this.tabDisplay.Controls.Add(this.lbDisplayItems);
            this.tabDisplay.Controls.Add(this.lbDisplay);
            this.tabDisplay.Controls.Add(this.cbDisplay);
            this.tabDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Size = new System.Drawing.Size(642, 373);
            this.tabDisplay.TabIndex = 5;
            this.tabDisplay.Text = "Display";
            this.tabDisplay.UseVisualStyleBackColor = true;
            // 
            // lbHiddenDisplayItems
            // 
            this.lbHiddenDisplayItems.FormattingEnabled = true;
            this.lbHiddenDisplayItems.Location = new System.Drawing.Point(58, 119);
            this.lbHiddenDisplayItems.Margin = new System.Windows.Forms.Padding(2);
            this.lbHiddenDisplayItems.Name = "lbHiddenDisplayItems";
            this.lbHiddenDisplayItems.Size = new System.Drawing.Size(101, 17);
            this.lbHiddenDisplayItems.TabIndex = 4;
            this.lbHiddenDisplayItems.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(254, 119);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Items Not Paid";
            // 
            // lbDisplayItems
            // 
            this.lbDisplayItems.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplayItems.FormattingEnabled = true;
            this.lbDisplayItems.ItemHeight = 16;
            this.lbDisplayItems.Location = new System.Drawing.Point(16, 151);
            this.lbDisplayItems.Margin = new System.Windows.Forms.Padding(2);
            this.lbDisplayItems.Name = "lbDisplayItems";
            this.lbDisplayItems.Size = new System.Drawing.Size(612, 116);
            this.lbDisplayItems.TabIndex = 2;
            // 
            // lbDisplay
            // 
            this.lbDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplay.FormattingEnabled = true;
            this.lbDisplay.ItemHeight = 17;
            this.lbDisplay.Location = new System.Drawing.Point(16, 47);
            this.lbDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.lbDisplay.Name = "lbDisplay";
            this.lbDisplay.Size = new System.Drawing.Size(612, 55);
            this.lbDisplay.TabIndex = 1;
            // 
            // cbDisplay
            // 
            this.cbDisplay.FormattingEnabled = true;
            this.cbDisplay.Location = new System.Drawing.Point(226, 13);
            this.cbDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.cbDisplay.Name = "cbDisplay";
            this.cbDisplay.Size = new System.Drawing.Size(198, 21);
            this.cbDisplay.TabIndex = 0;
            this.cbDisplay.SelectedIndexChanged += new System.EventHandler(this.CbDisplay_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 420);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabStart.ResumeLayout(false);
            this.tabStart.PerformLayout();
            this.tabTasks.ResumeLayout(false);
            this.tabTasks.PerformLayout();
            this.tabClean.ResumeLayout(false);
            this.tabClean.PerformLayout();
            this.tabGarbage.ResumeLayout(false);
            this.tabGarbage.PerformLayout();
            this.tabItems.ResumeLayout(false);
            this.tabItems.PerformLayout();
            this.tabComplaint.ResumeLayout(false);
            this.tabComplaint.PerformLayout();
            this.tabDisplay.ResumeLayout(false);
            this.tabDisplay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClean;
        private System.Windows.Forms.Button btnCleaner;
        private System.Windows.Forms.Label lblCleaner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabGarbage;
        private System.Windows.Forms.Button btnGarbage;
        private System.Windows.Forms.Label lblGarbage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbStudents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbItemPrice;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.TabPage tabComplaint;
        private System.Windows.Forms.TextBox tbComplaint;
        private System.Windows.Forms.ComboBox cbStudents;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TabPage tabStart;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbStudentName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbStudentList;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimeCleaning;
        private System.Windows.Forms.Label lblTimeGarbage;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.ListBox lbDisplay;
        private System.Windows.Forms.ComboBox cbDisplay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbDisplayItems;
        private System.Windows.Forms.ListBox lbHiddenDisplayItems;
        private System.Windows.Forms.TextBox tbGrocer;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDelItem;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.Label lblCleaning;
        private System.Windows.Forms.ListBox lbTasks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTasking;
        private System.Windows.Forms.Button btnRemoveCleaning;
        private System.Windows.Forms.Button btnAddCleaning;
        private System.Windows.Forms.TextBox tbCleaning;
        private System.Windows.Forms.Label lblTimeTask;
        private System.Windows.Forms.Button button1;
    }
}

