using System.Windows.Media;

namespace SenneGameWpf
{
    public interface IProjectiel
    {
        void Beweeg();
        Drawing Teken_jezelf();
        bool Gestopt { get; }
        void Stop(); 
    }
}