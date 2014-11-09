JobXML
======

Trimble JobXML files (*.jxl)  reader/writer implementation written in c#

```c#
var xs = new XmlSerializer(typeof(JOBFile));
JOBFile job;

using (var stm = dlg.OpenFile())
{
	job = (JOBFile)xs.Deserialize(stm);
}

MessageBox.Show(job.jobName);

```