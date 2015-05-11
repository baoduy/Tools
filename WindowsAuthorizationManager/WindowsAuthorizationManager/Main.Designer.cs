namespace WindowsAuthorizationManager
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.menu_Environment = new System.Windows.Forms.ToolStripDropDownButton();
            this.menu_SelectedConnectionString = new System.Windows.Forms.ToolStripLabel();
            this.groupOption = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.op_UserRoleScope = new System.Windows.Forms.RadioButton();
            this.op_UserGroupScope = new System.Windows.Forms.RadioButton();
            this.op_ScopeRoleUser = new System.Windows.Forms.RadioButton();
            this.op_RolesInApp = new System.Windows.Forms.RadioButton();
            this.op_ScopeGroupUser = new System.Windows.Forms.RadioButton();
            this.data_AppNames = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupAction = new System.Windows.Forms.GroupBox();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menu_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.op_UserScopeGroupRole = new System.Windows.Forms.RadioButton();
            this.toolStrip.SuspendLayout();
            this.groupOption.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupAction.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Environment,
            this.menu_SelectedConnectionString});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // menu_Environment
            // 
            this.menu_Environment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menu_Environment.Image = ((System.Drawing.Image)(resources.GetObject("menu_Environment.Image")));
            this.menu_Environment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_Environment.Name = "menu_Environment";
            this.menu_Environment.Size = new System.Drawing.Size(88, 22);
            this.menu_Environment.Text = "Environment";
            this.menu_Environment.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // menu_SelectedConnectionString
            // 
            this.menu_SelectedConnectionString.Name = "menu_SelectedConnectionString";
            this.menu_SelectedConnectionString.Size = new System.Drawing.Size(0, 22);
            // 
            // groupOption
            // 
            this.groupOption.Controls.Add(this.groupBox1);
            this.groupOption.Controls.Add(this.data_AppNames);
            this.groupOption.Controls.Add(this.label1);
            this.groupOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOption.Location = new System.Drawing.Point(0, 25);
            this.groupOption.Name = "groupOption";
            this.groupOption.Size = new System.Drawing.Size(784, 468);
            this.groupOption.TabIndex = 1;
            this.groupOption.TabStop = false;
            this.groupOption.Text = "Option";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.op_UserScopeGroupRole);
            this.groupBox1.Controls.Add(this.op_UserRoleScope);
            this.groupBox1.Controls.Add(this.op_UserGroupScope);
            this.groupBox1.Controls.Add(this.op_ScopeRoleUser);
            this.groupBox1.Controls.Add(this.op_RolesInApp);
            this.groupBox1.Controls.Add(this.op_ScopeGroupUser);
            this.groupBox1.Location = new System.Drawing.Point(93, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 165);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // op_UserRoleScope
            // 
            this.op_UserRoleScope.AutoSize = true;
            this.op_UserRoleScope.Location = new System.Drawing.Point(20, 114);
            this.op_UserRoleScope.Name = "op_UserRoleScope";
            this.op_UserRoleScope.Size = new System.Drawing.Size(263, 17);
            this.op_UserRoleScope.TabIndex = 4;
            this.op_UserRoleScope.TabStop = true;
            this.op_UserRoleScope.Text = "Export All Users, Roles and Scopes in Applications";
            this.op_UserRoleScope.UseVisualStyleBackColor = true;
            // 
            // op_UserGroupScope
            // 
            this.op_UserGroupScope.AutoSize = true;
            this.op_UserGroupScope.Location = new System.Drawing.Point(20, 65);
            this.op_UserGroupScope.Name = "op_UserGroupScope";
            this.op_UserGroupScope.Size = new System.Drawing.Size(260, 17);
            this.op_UserGroupScope.TabIndex = 2;
            this.op_UserGroupScope.TabStop = true;
            this.op_UserGroupScope.Text = "Export All Users, Group and Scope in Applications";
            this.op_UserGroupScope.UseVisualStyleBackColor = true;
            // 
            // op_ScopeRoleUser
            // 
            this.op_ScopeRoleUser.AutoSize = true;
            this.op_ScopeRoleUser.Location = new System.Drawing.Point(20, 91);
            this.op_ScopeRoleUser.Name = "op_ScopeRoleUser";
            this.op_ScopeRoleUser.Size = new System.Drawing.Size(258, 17);
            this.op_ScopeRoleUser.TabIndex = 3;
            this.op_ScopeRoleUser.TabStop = true;
            this.op_ScopeRoleUser.Text = "Export All Scope, Roles and Users in Applications";
            this.op_ScopeRoleUser.UseVisualStyleBackColor = true;
            // 
            // op_RolesInApp
            // 
            this.op_RolesInApp.AutoSize = true;
            this.op_RolesInApp.Location = new System.Drawing.Point(20, 19);
            this.op_RolesInApp.Name = "op_RolesInApp";
            this.op_RolesInApp.Size = new System.Drawing.Size(161, 17);
            this.op_RolesInApp.TabIndex = 0;
            this.op_RolesInApp.Text = "Export All Roles Assignments";
            this.op_RolesInApp.UseVisualStyleBackColor = true;
            // 
            // op_ScopeGroupUser
            // 
            this.op_ScopeGroupUser.AutoSize = true;
            this.op_ScopeGroupUser.Location = new System.Drawing.Point(20, 42);
            this.op_ScopeGroupUser.Name = "op_ScopeGroupUser";
            this.op_ScopeGroupUser.Size = new System.Drawing.Size(265, 17);
            this.op_ScopeGroupUser.TabIndex = 1;
            this.op_ScopeGroupUser.TabStop = true;
            this.op_ScopeGroupUser.Text = "Export All Scope, Groups and Users in Applications";
            this.op_ScopeGroupUser.UseVisualStyleBackColor = true;
            // 
            // data_AppNames
            // 
            this.data_AppNames.Location = new System.Drawing.Point(93, 29);
            this.data_AppNames.Name = "data_AppNames";
            this.data_AppNames.Size = new System.Drawing.Size(293, 20);
            this.data_AppNames.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application";
            // 
            // groupAction
            // 
            this.groupAction.Controls.Add(this.btn_Reload);
            this.groupAction.Controls.Add(this.btn_Export);
            this.groupAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupAction.Location = new System.Drawing.Point(0, 493);
            this.groupAction.Name = "groupAction";
            this.groupAction.Size = new System.Drawing.Size(784, 47);
            this.groupAction.TabIndex = 2;
            this.groupAction.TabStop = false;
            // 
            // btn_Reload
            // 
            this.btn_Reload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Reload.Enabled = false;
            this.btn_Reload.Location = new System.Drawing.Point(3, 16);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(122, 28);
            this.btn_Reload.TabIndex = 1;
            this.btn_Reload.Text = "Reload AzMan Data";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Export.Enabled = false;
            this.btn_Export.Location = new System.Drawing.Point(706, 16);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 28);
            this.btn_Export.TabIndex = 0;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menu_Status
            // 
            this.menu_Status.Name = "menu_Status";
            this.menu_Status.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // op_UserScopeGroupRole
            // 
            this.op_UserScopeGroupRole.AutoSize = true;
            this.op_UserScopeGroupRole.Location = new System.Drawing.Point(20, 137);
            this.op_UserScopeGroupRole.Name = "op_UserScopeGroupRole";
            this.op_UserScopeGroupRole.Size = new System.Drawing.Size(293, 17);
            this.op_UserScopeGroupRole.TabIndex = 5;
            this.op_UserScopeGroupRole.TabStop = true;
            this.op_UserScopeGroupRole.Text = "Export All Users, Scope, Group and Roles in Applications";
            this.op_UserScopeGroupRole.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupOption);
            this.Controls.Add(this.groupAction);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Windows Authorization Manager ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupOption.ResumeLayout(false);
            this.groupOption.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupAction.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton menu_Environment;
        private System.Windows.Forms.ToolStripLabel menu_SelectedConnectionString;
        private System.Windows.Forms.GroupBox groupOption;
        private System.Windows.Forms.TextBox data_AppNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupAction;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel menu_Status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton op_RolesInApp;
        private System.Windows.Forms.RadioButton op_ScopeGroupUser;
        private System.Windows.Forms.RadioButton op_ScopeRoleUser;
        private System.Windows.Forms.RadioButton op_UserGroupScope;
        private System.Windows.Forms.RadioButton op_UserRoleScope;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.RadioButton op_UserScopeGroupRole;
    }
}

