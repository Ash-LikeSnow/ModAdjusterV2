using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRage.Game;
using VRage.Render.Particles;

namespace ModAdjusterV2.Definitions
{
    public class ParticleEffect : Definition
    {
		public int ParticleId;

		public float Length = 10f;

		public float Preload;

		public bool LowRes;

		public bool Loop;

		public float DurationMin;

		public float DurationMax;

		public int Version;

		//public List<ParticleGeneration> ParticleGenerations;

		//public List<ParticleLight> ParticleLights;

		public float DistanceMax;

		public float Priority = 1f;

	}
}
