using UnityEngine;

// Classe Parent des primitives dynamiques
// Dans cette relation, le parent s'occupe des g�n�ralit�s entourant la gestion du calcul 
// des sommets, des triangles, des normales et des tangentes, ainsi que celles entourant la cr�ation du maillage en g�n�ral.
// L'enfant impl�mente les sp�cificit�s entourant le calcul des sommets, des triangles et des coordonn�es de texture.
public abstract class PrimitiveDynamique : MonoBehaviour
{
    public const int NbTrianglesParTuile = 2;
    public const int NbSommetsParTriangle = 3;
    public const int NbSommetsParTuiles = 4;

    protected Vector3 �tendue { get; private set; } // �tendue de la primitive dans l'espace
    string NomMaillage { get; set; }
    protected Mesh Maillage { get; set; }
    protected Vector3[] Sommets { get; set; }  // Les diff�rents sommets (vertices) de la surface
    protected int[] ListeTriangles { get; set; }
    protected Vector3 Origine { get; set; }  // L'origine du vecteur est fix�e de mani�re � ce que le centre de la surface 
                                             // (croisement des axes de rotation) soit situ� au point (0, 0, 0) de l'espace virtuel.
    protected Vector2[] Coordonn�esTexture { get; set; } // Les coordonn�es permettant l'application de la texture sur la primitive.
    protected int NbSommets { get; set; } // Nombre de sommets de la surface
    protected Vector2 DeltaTexture { get; set; } // Variations horizontale et verticale dans les coordonn�es de texture

    public virtual void InitialiserPrimitive(string nomMaillage, Vector3 �tendue, Material mat�riau, bool estCarrel�)
    {
        //Permet de terminer la construction de l'objet
        NomMaillage = nomMaillage;
        �tendue = �tendue;
        GetComponent<MeshRenderer>().material = mat�riau;
        CalculerDonn�esInitiales(estCarrel�);
        G�n�rerMaillage();
        MeshCollider maillageCollision = GetComponent<MeshCollider>();
        if (maillageCollision != null)
        {
            maillageCollision.sharedMesh = G�n�rerMaillageCollision();
        }
        // Une fois la construction compl�t�e, on active la primitive
        this.gameObject.SetActive(true);
    }

    protected virtual void CalculerDonn�esInitiales(bool estCarrel�)
    {
        Origine = new Vector3(-�tendue.x / 2, 0, -�tendue.y / 2);
    }

    private void G�n�rerMaillage()
    {
        Maillage = new Mesh();
        GetComponent<MeshFilter>().mesh = Maillage;
        Maillage.name = NomMaillage;
        G�n�rerSommets();
        G�n�rerListeTriangles();
        G�n�rerCoordonn�esTexture();
        Maillage.vertices = Sommets;
        Maillage.triangles = ListeTriangles;
        Maillage.uv = Coordonn�esTexture;
        Maillage.RecalculateNormals();
        Maillage.RecalculateTangents();
    }

    protected abstract void G�n�rerSommets();

    protected abstract void G�n�rerListeTriangles();

    protected abstract void G�n�rerCoordonn�esTexture();

    protected virtual Mesh G�n�rerMaillageCollision() //Peut �tre surcharg�e pour g�n�rer une version simplifi�e du Mesh
    {
        return Maillage;
    }

    protected static void AjouterTriangle(int[] triangles, int indexSommetA, int indexSommetB, int indexSommetC, ref int indexTriangle)
    {
        triangles[indexTriangle++] = indexSommetA;
        triangles[indexTriangle++] = indexSommetB;
        triangles[indexTriangle++] = indexSommetC;
    }
}