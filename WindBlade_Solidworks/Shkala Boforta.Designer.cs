namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.таблица1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.microsoft_Access_База_данныхDataSet = new WindowsFormsApplication1.Microsoft_Access_База_данныхDataSet();
            this.таблица1TableAdapter = new WindowsFormsApplication1.Microsoft_Access_База_данныхDataSetTableAdapters.Таблица1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблица1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.microsoft_Access_База_данныхDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn,
            this.сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn,
            this.дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.таблица1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(2, -2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(905, 401);
            this.dataGridView1.TabIndex = 0;
            // 
            // сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn
            // 
            this.сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn.DataPropertyName = "СЛОВЕСНОЕ ОПИСАНИЕ СИЛЫ ВЕТРА";
            this.сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn.HeaderText = "СЛОВЕСНОЕ ОПИСАНИЕ СИЛЫ ВЕТРА";
            this.сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn.Name = "сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn";
            this.сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn
            // 
            this.сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn.DataPropertyName = "СРЕДНЯЯ СКОРОСТЬ ВЕТРА, М/С (КМ/Ч)";
            this.сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn.HeaderText = "СРЕДНЯЯ СКОРОСТЬ ВЕТРА, М/С (КМ/Ч)";
            this.сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn.Name = "сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn";
            this.сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn
            // 
            this.дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn.DataPropertyName = "ДЕЙСТВИЕ ВЕТРА";
            this.дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn.HeaderText = "ДЕЙСТВИЕ ВЕТРА";
            this.дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn.Name = "дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn";
            this.дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn.ReadOnly = true;
            this.дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn.Width = 650;
            // 
            // таблица1BindingSource
            // 
            this.таблица1BindingSource.DataMember = "Таблица1";
            this.таблица1BindingSource.DataSource = this.microsoft_Access_База_данныхDataSet;
            // 
            // microsoft_Access_База_данныхDataSet
            // 
            this.microsoft_Access_База_данныхDataSet.DataSetName = "Microsoft_Access_База_данныхDataSet";
            this.microsoft_Access_База_данныхDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // таблица1TableAdapter
            // 
            this.таблица1TableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 341);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Шкала Бофорта";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблица1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.microsoft_Access_База_данныхDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Microsoft_Access_База_данныхDataSet microsoft_Access_База_данныхDataSet;
        private System.Windows.Forms.BindingSource таблица1BindingSource;
        private Microsoft_Access_База_данныхDataSetTableAdapters.Таблица1TableAdapter таблица1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn сЛОВЕСНОЕОПИСАНИЕСИЛЫВЕТРАDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сРЕДНЯЯСКОРОСТЬВЕТРАМСКМЧDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дЕЙСТВИЕВЕТРАDataGridViewTextBoxColumn;








    }
}