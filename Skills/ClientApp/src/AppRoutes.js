import { Navigate } from 'react-router-dom';
import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { Home } from "./components/Home";
import SkillList from './components/skill';


const AppRoutes = [
  
  {
    path: '/character/publish/:characterId',
    requireAuth: true,
    element: <SkillList />
  },
  {
    path: '/character/:characterId',
    element: <SkillList />
  },
  {
    path: '/character',
    element: <SkillList />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/',
    index: true,
    element: <Navigate to ='/character' replace />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
