
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openHeaderButton = new System.Windows.Forms.Button();
            this.StructuresCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.extensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.pdfRadioButton = new System.Windows.Forms.RadioButton();
            this.docxRadioButton = new System.Windows.Forms.RadioButton();
            this.pathOfHeaderLabel = new System.Windows.Forms.Label();
            this.pathOfSaveFileButton = new System.Windows.Forms.Button();
            this.pathOfFileLabel = new System.Windows.Forms.Label();
            this.createFileButton = new System.Windows.Forms.Button();
            this.extensionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // openHeaderButton
            // 
            this.openHeaderButton.Location = new System.Drawing.Point(12, 12);
            this.openHeaderButton.Name = "openHeaderButton";
            this.openHeaderButton.Size = new System.Drawing.Size(119, 39);
            this.openHeaderButton.TabIndex = 0;
            this.openHeaderButton.Text = "Открыть header ";
            this.openHeaderButton.UseVisualStyleBackColor = true;
            this.openHeaderButton.Click += new System.EventHandler(this.openHeaderButton_Click);
            // 
            // StructuresCheckedListBox
            // 
            this.StructuresCheckedListBox.FormattingEnabled = true;
            this.StructuresCheckedListBox.Location = new System.Drawing.Point(14, 66);
            this.StructuresCheckedListBox.Name = "StructuresCheckedListBox";
            this.StructuresCheckedListBox.Size = new System.Drawing.Size(258, 214);
            this.StructuresCheckedListBox.TabIndex = 1;
            this.StructuresCheckedListBox.Visible = false;
            // 
            // extensionsGroupBox
            // 
            this.extensionsGroupBox.Controls.Add(this.pdfRadioButton);
            this.extensionsGroupBox.Controls.Add(this.docxRadioButton);
            this.extensionsGroupBox.Location = new System.Drawing.Point(298, 66);
            this.extensionsGroupBox.Name = "extensionsGroupBox";
            this.extensionsGroupBox.Size = new System.Drawing.Size(119, 107);
            this.extensionsGroupBox.TabIndex = 2;
            this.extensionsGroupBox.TabStop = false;
            this.extensionsGroupBox.Text = "Формат файла";
            this.extensionsGroupBox.Visible = false;
            // 
            // pdfRadioButton
            // 
            this.pdfRadioButton.AutoSize = true;
            this.pdfRadioButton.Location = new System.Drawing.Point(6, 42);
            this.pdfRadioButton.Name = "pdfRadioButton";
            this.pdfRadioButton.Size = new System.Drawing.Size(43, 17);
            this.pdfRadioButton.TabIndex = 1;
            this.pdfRadioButton.Text = ".pdf";
            this.pdfRadioButton.UseVisualStyleBackColor = true;
            // 
            // docxRadioButton
            // 
            this.docxRadioButton.AutoSize = true;
            this.docxRadioButton.Checked = true;
            this.docxRadioButton.Location = new System.Drawing.Point(6, 19);
            this.docxRadioButton.Name = "docxRadioButton";
            this.docxRadioButton.Size = new System.Drawing.Size(51, 17);
            this.docxRadioButton.TabIndex = 0;
            this.docxRadioButton.TabStop = true;
            this.docxRadioButton.Text = ".docx";
            this.docxRadioButton.UseVisualStyleBackColor = true;
            // 
            // pathOfHeaderLabel
            // 
            this.pathOfHeaderLabel.AutoSize = true;
            this.pathOfHeaderLabel.Location = new System.Drawing.Point(153, 25);
            this.pathOfHeaderLabel.Name = "pathOfHeaderLabel";
            this.pathOfHeaderLabel.Size = new System.Drawing.Size(0, 13);
            this.pathOfHeaderLabel.TabIndex = 3;
            this.pathOfHeaderLabel.Visible = false;
            // 
            // pathOfSaveFileButton
            // 
            this.pathOfSaveFileButton.Location = new System.Drawing.Point(298, 200);
            this.pathOfSaveFileButton.Name = "pathOfSaveFileButton";
            this.pathOfSaveFileButton.Size = new System.Drawing.Size(119, 42);
            this.pathOfSaveFileButton.TabIndex = 4;
            this.pathOfSaveFileButton.Text = "Сохранить в...";
            this.pathOfSaveFileButton.UseVisualStyleBackColor = true;
            this.pathOfSaveFileButton.Visible = false;
            this.pathOfSaveFileButton.Click += new System.EventHandler(this.pathOfSaveFileButton_Click);
            // 
            // pathOfFileLabel
            // 
            this.pathOfFileLabel.AutoSize = true;
            this.pathOfFileLabel.Location = new System.Drawing.Point(298, 266);
            this.pathOfFileLabel.Name = "pathOfFileLabel";
            this.pathOfFileLabel.Size = new System.Drawing.Size(0, 13);
            this.pathOfFileLabel.TabIndex = 5;
            this.pathOfFileLabel.Visible = false;
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(458, 200);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(131, 42);
            this.createFileButton.TabIndex = 6;
            this.createFileButton.Text = "Создать файл";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Visible = false;
            this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 301);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.pathOfFileLabel);
            this.Controls.Add(this.pathOfSaveFileButton);
            this.Controls.Add(this.pathOfHeaderLabel);
            this.Controls.Add(this.extensionsGroupBox);
            this.Controls.Add(this.StructuresCheckedListBox);
            this.Controls.Add(this.openHeaderButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.extensionsGroupBox.ResumeLayout(false);
            this.extensionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openHeaderButton;
        private System.Windows.Forms.CheckedListBox StructuresCheckedListBox;
        private System.Windows.Forms.GroupBox extensionsGroupBox;
        private System.Windows.Forms.RadioButton pdfRadioButton;
        private System.Windows.Forms.RadioButton docxRadioButton;
        private System.Windows.Forms.Label pathOfHeaderLabel;
        private System.Windows.Forms.Button pathOfSaveFileButton;
        private System.Windows.Forms.Label pathOfFileLabel;
        private System.Windows.Forms.Button createFileButton;
    }
}

