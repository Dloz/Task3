namespace Forms {
    partial class CallHistory {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.automaticTelephoneStationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.callHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.callDurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startCallDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endCallDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetTelephoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senderTelephoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.automaticTelephoneStationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.callHistoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callDurationDataGridViewTextBoxColumn,
            this.startCallDataGridViewTextBoxColumn,
            this.endCallDataGridViewTextBoxColumn,
            this.targetTelephoneNumberDataGridViewTextBoxColumn,
            this.senderTelephoneNumberDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.callHistoryBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(646, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // automaticTelephoneStationBindingSource
            // 
            this.automaticTelephoneStationBindingSource.DataSource = typeof(ATS.ATS.AutomaticTelephoneStation);
            // 
            // callHistoryBindingSource
            // 
            this.callHistoryBindingSource.DataMember = "CallHistory";
            this.callHistoryBindingSource.DataSource = this.automaticTelephoneStationBindingSource;
            // 
            // callDurationDataGridViewTextBoxColumn
            // 
            this.callDurationDataGridViewTextBoxColumn.DataPropertyName = "CallDuration";
            this.callDurationDataGridViewTextBoxColumn.HeaderText = "CallDuration";
            this.callDurationDataGridViewTextBoxColumn.Name = "callDurationDataGridViewTextBoxColumn";
            this.callDurationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startCallDataGridViewTextBoxColumn
            // 
            this.startCallDataGridViewTextBoxColumn.DataPropertyName = "StartCall";
            this.startCallDataGridViewTextBoxColumn.HeaderText = "StartCall";
            this.startCallDataGridViewTextBoxColumn.Name = "startCallDataGridViewTextBoxColumn";
            this.startCallDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endCallDataGridViewTextBoxColumn
            // 
            this.endCallDataGridViewTextBoxColumn.DataPropertyName = "EndCall";
            this.endCallDataGridViewTextBoxColumn.HeaderText = "EndCall";
            this.endCallDataGridViewTextBoxColumn.Name = "endCallDataGridViewTextBoxColumn";
            // 
            // targetTelephoneNumberDataGridViewTextBoxColumn
            // 
            this.targetTelephoneNumberDataGridViewTextBoxColumn.DataPropertyName = "TargetTelephoneNumber";
            this.targetTelephoneNumberDataGridViewTextBoxColumn.HeaderText = "TargetTelephoneNumber";
            this.targetTelephoneNumberDataGridViewTextBoxColumn.Name = "targetTelephoneNumberDataGridViewTextBoxColumn";
            this.targetTelephoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // senderTelephoneNumberDataGridViewTextBoxColumn
            // 
            this.senderTelephoneNumberDataGridViewTextBoxColumn.DataPropertyName = "SenderTelephoneNumber";
            this.senderTelephoneNumberDataGridViewTextBoxColumn.HeaderText = "SenderTelephoneNumber";
            this.senderTelephoneNumberDataGridViewTextBoxColumn.Name = "senderTelephoneNumberDataGridViewTextBoxColumn";
            this.senderTelephoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CallHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CallHistory";
            this.Text = "CallHistory";
            this.Load += new System.EventHandler(this.CallHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.automaticTelephoneStationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.callHistoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn callDurationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startCallDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endCallDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetTelephoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senderTelephoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource callHistoryBindingSource;
        private System.Windows.Forms.BindingSource automaticTelephoneStationBindingSource;
    }
}