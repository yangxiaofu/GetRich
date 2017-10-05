using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Core{
	public class NavMeshBaker : MonoBehaviour {
		NavMeshSurface _surface;
		void Start()
		{
			_surface = GetComponent<NavMeshSurface>();

			if(!_surface) Debug.LogError(
				"You need to attach a NavMeshSurface component to the gameobject " + this.gameObject.name
			);

			_surface.BuildNavMesh();
		}
	}

}
