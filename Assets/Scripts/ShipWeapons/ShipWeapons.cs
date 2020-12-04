namespace DefaultNamespace.ShipWeapons
{
    public interface ShipWeapons
    {
        void Select();

        void Unselect();
        
        void Fire();

        float getFireRate();
        
    }
}